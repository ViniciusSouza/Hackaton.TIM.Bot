using Hackaton.TIM.Bot.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Hackaton.TIM.Bot.Dialogs
{
    [Serializable]
    public class QnADialog : IDialog<bool>
    {
        private string _baseUrl = "https://westus.api.cognitive.microsoft.com/qnamaker/v2.0/knowledgebases/";
        private string _method = "/generateAnswer";

        private string _qnaURL;
        private string _qnaKey;

        private int _retry;
        private int _tries;
        private bool _supressStart;
        private string _subject;
        public QnADialog(string kbId, bool supressStart, string subject = "")
        {
            _subject = subject;
            _qnaURL = _baseUrl + kbId + _method;
            _qnaKey = ConfigurationManager.AppSettings["QnAKey"];
            _retry = 3;
            _tries = 1;
            _supressStart = supressStart;
        }

        public async Task StartAsync(IDialogContext context)
        {
            if (!_supressStart)
            {
                string message = "Ok, make your question!";
                PromptDialog.Text(context, ResumeAfterQuestion, message);
            }
            else
            {
                string message = context.Activity.AsMessageActivity().Text;
                await QueryQna(context, message);
            }
        }

        private async Task ResumeAfterQuestion(IDialogContext context, IAwaitable<string> result)
        {
            await QueryQna(context, await result);
        }

        private async Task QueryQna(IDialogContext context, string result)
        {
            var request = new AnswerRequest();
            request.Question = result;

            List<AnswerResponse> response = await getAnswer(request);
            if (response != null)
            {
                int mediaMinima = 45;
                int maximoRespostas = 2;
                var respostasAcimaMedia = response.Where(s => s.Score > mediaMinima).ToList();
                if (respostasAcimaMedia.Count != 0)
                {
                    foreach (var item in respostasAcimaMedia)
                    {
                        var reply = context.MakeMessage();
                        reply.Text = "**" + item.Questions[0] + "**<br/>" + item.Answer;
                        reply.AddHeroCard("Esta resposta te ajudou?", new[] { "Sim", "Não" });
                        await context.PostAsync(reply);
                        context.Wait(RespostaSatistatoria);

                        maximoRespostas--;
                        if (maximoRespostas == 0)
                            break;
                    }
                }
                else
                {
                    var reply = context.MakeMessage();
                    if (_tries == 1)
                    {
                        reply.Text = $"Certo! Identifiquei que você quer saber sobre {_subject}. Faça sua pergunta.";
                        _tries++;
                    }
                    else
                    {
                        reply.Text = "Não encontrei sua resposta.";
                        reply.AddHeroCard("Quer fazer outra pergunta?", new[] { "Sim", "Não" });
                    }
                    await context.PostAsync(reply);
                    context.Wait(RespostaRefazerPergunta);
                }
            }
            else
            {
                if (_tries < _retry)
                    PromptDialog.Text(context, ResumeAfterQuestion, "Não pude encontrar sua resposta, tente novamente...");
                else
                    context.Done(false);

                _tries++;
            }
        }

        private async Task RespostaSatistatoria(IDialogContext context, IAwaitable<object> result)
        {
            var answer = ((Activity)await result).Text;
            if (answer == "Yes")
            {
                context.Done(true);
            }
            else
            {
                PromptDialog.Text(context, ResumeAfterQuestion, "Please, make another question:");
            }

        }

        private async Task RespostaRefazerPergunta(IDialogContext context, IAwaitable<Object> result)
        {
            var answer = ((Activity)await result).Text;
            if (answer != "No")
            {
                if (_tries == 1)
                {
                    await QueryQna(context, answer);
                }
                else
                {
                    PromptDialog.Text(context, ResumeAfterQuestion, "Make your question again...");
                }
            }
            else
            {
                context.Done(answer);
            }
        }



        private async Task<List<AnswerResponse>> getAnswer(AnswerRequest question)
        {
            //using (var client = new HttpClient())
            //{
            //    client.DefaultRequestHeaders.Add("ocp-apim-subscription-key", _qnaKey);
            //    var body = JsonConvert.SerializeObject(question);
            //    var content = new StringContent(body, Encoding.ASCII, "application/json");
            //    var response = await client.PostAsync(_qnaURL, content);
            //    var responseTxt = await response.Content.ReadAsStringAsync();
            //}
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_qnaURL);
            req.Method = WebRequestMethods.Http.Post;
            req.ContentType = "application/json; charset=utf-8";
            req.Accept = "application/json; charset=utf-8";
            req.Headers.Add("ocp-apim-subscription-key", _qnaKey);

            string postData = JsonConvert.SerializeObject(question);

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            req.ContentLength = byteArray.Length;

            Stream dataStream = req.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            HttpWebResponse response = await req.GetResponseAsync() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                responseFromServer = HttpUtility.HtmlDecode(responseFromServer);

                var ans = JsonConvert.DeserializeObject<AnswersList>(responseFromServer);
                if (ans.Answers.Count >= 0)
                    return ans.Answers.ToList();
            }
            return null;
        }
    }
}