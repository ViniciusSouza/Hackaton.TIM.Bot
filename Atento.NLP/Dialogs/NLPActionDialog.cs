using Atento.NLP.Models.Answer;
using Atento.NLP.Services.Interfaces;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Threading.Tasks;

namespace Atento.NLP.Dialogs
{
    [Serializable]
    public class NLPActionDialog : IDialog<NLPResult>
    {
        public virtual async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync(this.prompt);
            context.Wait(MessageReceivedAsync);
        }

        private readonly INLPService nlpService;
        private string contextId;
        private string prompt;

        /// <summary>
        /// Creates an instance of LuisActionDialog.
        /// </summary>
        /// <param name="luisService"> The Luis service.</param>
        /// <param name="contextId"> The contextId for Luis dialog returned in Luis result.</param>
        /// <param name="prompt"> The prompt that should be asked from user.</param>
        public NLPActionDialog(INLPService nlpService, string contextId, string prompt)
        {
            SetField.NotNull(out this.nlpService, nameof(nlpService), nlpService);
            SetField.NotNull(out this.contextId, nameof(contextId), contextId);
            this.prompt = prompt;
        }

        protected virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> item)
        {
            NLPResult result = null;
            var message = await item;
            if (this.nlpService is Atento.NLP.Services.Implementations.LuisService)
            {
                var luisRequest = new LuisRequest(query: message.Text, contextId: this.contextId);
                result = await (nlpService as Atento.NLP.Services.Implementations.LuisService).QueryAsync(luisRequest);
            }
            else
            {
                result = await nlpService.QueryAsync(message.Text);
            }
            if (result.Dialog.Status != DialogResponse.DialogStatus.Finished)
            {
                this.contextId = result.Dialog.ContextId;
                this.prompt = result.Dialog.Prompt;
                await context.PostAsync(this.prompt);
                context.Wait(MessageReceivedAsync);
            }
            else
            {
                context.Done(result);
            }
        }
    }
}
