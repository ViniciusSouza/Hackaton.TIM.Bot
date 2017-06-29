using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Hackaton.TIM.Bot.Models;
using System.Configuration;

namespace Hackaton.TIM.Bot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {

            try
            {
                var activity = await result as Activity;

                StateClient stateClient = activity.GetStateClient();
                BotData userData = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.Conversation.Id);

              //    var dialog = userData.GetProperty<string>("Dialog");

                var dialog = "faq";
                if (dialog != null)
                {
                    switch (dialog)
                    {
                        case "detalhamentoconta":
                            context.Call(new DetalhamentoDeUsoDialog(DetalhamentoContaRequest.BuildForm), ResumeAfter);
                            break;
                        case "faq":
                            context.Call(new LuisDialog(), ResumeAfter);
                            break;
                        case "servicos":
                            context.Call(new ServicosDialog(), ResumeAfter);
                            break;
                        default:
                            context.Wait(MessageReceivedAsync);
                            break;
                    }
                }
                else
                {
                    context.Wait(MessageReceivedAsync);
                }
            }
            catch (Exception ex)
            {
                var a = ex;
            }
        }

        private async Task ResumeAfter(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Qualquer coisa é só me chamar que eu estarei por aqui...");
            context.Wait(MessageReceivedAsync);
        }

        
    }
}