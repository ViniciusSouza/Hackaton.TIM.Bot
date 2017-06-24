using Atento.NLP.Models.Answer;
using Atento.NLP.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atento.NLP.Services.Implementations
{
    public class WatsonService : INLPService
    {
        private string _workspaceId, _userPassword;
        public WatsonService(string workspaceId, string userPassword)
        {
            _workspaceId = workspaceId;
            _userPassword = userPassword;
        }
        public async Task<NLPResult> QueryAsync(string queryString)
        {
            // TODO: Param
          

            string requestUrl = $"https://gateway.watsonplatform.net/conversation/api/v1/workspaces/{_workspaceId}/message?version={DateTime.Now.ToString("yyyy-MM-dd")}";

            Conversation watsonConversation = new Conversation(queryString);

            var restClient = new RestSharp.RestClient(requestUrl);
            var restRequest = new RestSharp.RestRequest(RestSharp.Method.POST);

            restRequest.AddHeader("Authorization", $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes(_userPassword))}");
            restRequest.AddJsonBody(watsonConversation);

            WatsonResponse watsonResponse = new WatsonResponse();

            await restClient.ExecutePostTaskAsync<WatsonResponse>(restRequest).ContinueWith(
                (restResponse) =>
                {
                    if (restResponse.IsCompleted)
                    {
                        watsonResponse = Newtonsoft.Json.JsonConvert.
                        DeserializeObject<WatsonResponse>(restResponse.Result.Content);
                    }
                });

            NLPResult nlpResult = new NLPResult(new WatsonEntityQuery(), this);

            nlpResult.Intent.Name = watsonResponse.intents.First().intent;
            nlpResult.Intent.Score = watsonResponse.intents.First().confidence;

            watsonResponse.entities.ForEach((watsonEntity) =>
            {
                nlpResult.Entities.Add(new NLPEntity { Name = watsonEntity.entity, Value = watsonEntity.value, Score = watsonEntity.confidence });
            });

            return nlpResult;
        }
    }

    #region WatsonModels
    class Conversation
    {
        [JsonProperty("input")]
        public Input Input { get; set; }

        public Conversation(string queryString)
        {
            Input = new Input() { Text = queryString };
        }
    }

    class Input
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    class WatsonResponse
    {
        public IList<WatsonIntent> intents { get; set; }

        public List<WatsonEntity> entities { get; set; }
    }

    class WatsonIntent
    {
        public string intent { get; set; }

        public double confidence { get; set; }
    }

    class WatsonEntity
    {
        public string entity { get; set; }

        public string value { get; set; }

        public double confidence { get; set; }
    }

    #endregion
}