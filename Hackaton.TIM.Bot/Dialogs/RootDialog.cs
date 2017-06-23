using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

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
            var activity = await result as Activity;

            var microsoftAppId = "f9789938-7703-4ac2-9e17-8f0fe96dd7ab";
            var microsoftAppPassword = "b3ofAxnPp9xqeZbkfaHBdvs";
            var channelId = "webchat";

            StateClient stateClient = new StateClient(new MicrosoftAppCredentials(microsoftAppId, microsoftAppPassword));
            BotData userData = await stateClient.BotState.GetUserDataAsync(channelId, activity.From.Id);

            var dialog = userData.GetProperty<string>("Dialog");
            if (dialog != null)
            {
                switch (dialog)
                {
                    case "qnadialog":
                        context.Call(new QnADialog("40fd77cd-349d-4e31-8bab-9ee98c9f4b99"), ResumerAfter);
                        break;
                    case "nointernetdialog":
                        context.Call(new NoInternetDialog(), ResumerAfter);
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

        private async Task ResumerAfter(IDialogContext context, IAwaitable<bool> result)
        {
            await context.PostAsync("back to black");
            context.Wait(MessageReceivedAsync);
        }
    }
}