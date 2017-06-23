using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Hackaton.TIM.Bot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
            }
            else
            {
                await HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private async Task HandleSystemMessage(Activity activity)
        {
            if (activity.Type == ActivityTypes.Event)
            {
                var value = activity.Value.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    var microsoftAppId = "f9789938-7703-4ac2-9e17-8f0fe96dd7ab";
                    var microsoftAppPassword = "b3ofAxnPp9xqeZbkfaHBdvs";

                    StateClient stateClient = new StateClient(new MicrosoftAppCredentials(microsoftAppId, microsoftAppPassword));
                    BotData userData = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);

                    switch (value)
                    {
                        case "QnADialog":
                            userData.SetProperty("Dialog","QnADialog");
                            break;
                        case "NoInternetDialog":
                            userData.SetProperty("Dialog","NoInternetDialog");
                            break;
                        
                        case "Reset":
                            userData.RemoveProperty("Dialog");
                            break;
                        default:
                            userData.SetProperty("Dialog","RootDialog");
                            break;
                    }
                    await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);
                }
            }
            else if (activity.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (activity.Type == ActivityTypes.Ping)
            {
            }
        }
    }
}