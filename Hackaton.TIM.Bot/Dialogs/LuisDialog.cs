using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace Hackaton.TIM.Bot.Dialogs
{
    [Serializable]
    [LuisModel("037d4268-1cc4-454a-ad9c-3cc901ecffaa", "fdc9558fda374d078767a164c34fb768")]
    public class LuisDialog : LuisDialog<object>
    {
        [LuisIntent("4G")]
        public async Task QuatroG(IDialogContext context, LuisResult result)
        {

        }

        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Desculpe, não entendi sua pergunta.");
        }

        [LuisIntent("RegrasTarifacao")]
        public async Task RegrasTarifacao(IDialogContext context, LuisResult result)
        {
         //   context.Call(new QnADialog(), new ResumeAfter<object>(MessageReceived));
        }

        [LuisIntent("RoamingNacional")]
        public async Task RoamingNacional(IDialogContext context, LuisResult result)
        {

        }
    }
}