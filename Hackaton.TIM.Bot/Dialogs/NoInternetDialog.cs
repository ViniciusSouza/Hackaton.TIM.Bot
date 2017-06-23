using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Hackaton.TIM.Bot.Dialogs
{
    [Serializable]
    public class NoInternetDialog : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Welcome to n");
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("End n");
            context.Done<object>(null);
        }
    }
}