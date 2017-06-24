using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System.Threading;

namespace Hackaton.TIM.Bot.Dialogs
{
    [Serializable]
    [LuisModel("037d4268-1cc4-454a-ad9c-3cc901ecffaa", "fdc9558fda374d078767a164c34fb768")]
    public class LuisDialog : LuisDialog<object>
    {
     
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Desculpe, não entendi sua pergunta.");
        }
        
        [LuisIntent("ContaEPlanos")]
        public async Task ContaEPlanos(IDialogContext context, LuisResult result)
        {
           await context.Forward(new QnADialog("2cf64e89-4897-4e77-9b4e-7bbec9623f94", true, "Contas e planos"), AfterAnswer, context.Activity.AsMessageActivity(), CancellationToken.None);
        }

        [LuisIntent("4G")]
        public async Task QuatroG(IDialogContext context, LuisResult result)
        {
            await context.Forward(new QnADialog("40fd77cd-349d-4e31-8bab-9ee98c9f4b99", true, "4G"), AfterAnswer, context.Activity.AsMessageActivity(), CancellationToken.None);
        }

        [LuisIntent("RoamingNacional")]
        public async Task RoamingNacional(IDialogContext context, LuisResult result)
        {
            await context.Forward(new QnADialog("90ac20a8-210f-4cb4-b06c-b34e2b5cfd18", true, "Roaming nacional"), AfterAnswer, context.Activity.AsMessageActivity(), CancellationToken.None);

        }


        [LuisIntent("RegrasTarifacao")]
        public async Task RegrasTarifacao(IDialogContext context, LuisResult result)
        {
            await context.Forward(new QnADialog("33b77109-fb56-4d57-9201-b47d5c0f49c8", true, "Regras de tarifação"), AfterAnswer, context.Activity.AsMessageActivity(), CancellationToken.None);

        }

        private Task AfterAnswer(IDialogContext context, IAwaitable<bool> result)
        {
            throw new NotImplementedException();
        }
    }
}