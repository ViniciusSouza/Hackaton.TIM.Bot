using Atento.NLP.Models.Answer;
using Atento.NLP.Services.Implementations;
using Atento.NLP.Services.Interfaces;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Atento.NLP.Dialogs
{
    public delegate Task NLPIntentHandler(IDialogContext context, NLPResult nlpResult);
    public delegate Task NLPIntentActivityHandler(IDialogContext context, IAwaitable<IMessageActivity> message, NLPResult nlpResult);
    [Serializable]
    public class NLPDialog : IDialog<object>
    {
        public NLPDialog()
        {
            var services = MakeServicesFromAttributes();
            SetField.NotNull(out this.services, nameof(services), services);
        }

        protected readonly IReadOnlyList<INLPService> services;

        [NonSerialized]
        protected Dictionary<string, NLPIntentActivityHandler> handlerByIntent;


        public INLPService[] MakeServicesFromAttributes()
        {
            List<INLPService> services = new List<INLPService>();
            var type = this.GetType();
            var nlpModels = type.GetCustomAttributes<NLPServiceAttribute>(inherit: true);
            foreach (var item in nlpModels)
            {
                services.Add(NLPServiceFactory.Create(item.Type));
            }

            return services.ToArray<INLPService>();
        }


        public virtual async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceived);
        }

        protected virtual async Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> item)
        {
            var message = await item;
            var messageText = await GetQueryTextAsync(context, message);

            var tasks = this.services.Select(s => s.QueryAsync(messageText)).ToArray();
            var results = await Task.WhenAll(tasks);

            var winners = results.Where(r => r.Intent != null);

            var winner = this.BestResultFrom(winners);

            if (winner == null)
            {
                throw new InvalidOperationException("No winning intent selected from Luis results.");
            }

            if (winner.Dialog?.Status == DialogResponse.DialogStatus.Question)
            {
                var childDialog = await MakeActionDialog(winner.Service,
                                                                winner.Dialog.ContextId,
                                                                winner.Dialog.Prompt);
                context.Call(childDialog, ActionDialogFinished);
            }
            else
            {
                await DispatchToIntentHandler(context, item, winner.Intent, winner);
            }

        }

        protected virtual async Task ActionDialogFinished(IDialogContext context, IAwaitable<NLPResult> item)
        {
            var result = await item;
            var messageActivity = (IMessageActivity)context.Activity;
            await DispatchToIntentHandler(context, Awaitable.FromItem(messageActivity), BestIntentFrom(result), result);
        }

        protected virtual async Task DispatchToIntentHandler(IDialogContext context,
                                                         IAwaitable<IMessageActivity> item,
                                                         NLPIntent bestIntent,
                                                         NLPResult result)
        {
            if (this.handlerByIntent == null)
            {
                this.handlerByIntent = new Dictionary<string, NLPIntentActivityHandler>(GetHandlersByIntent());
            }

            NLPIntentActivityHandler handler = null;
            if (result == null || !this.handlerByIntent.TryGetValue(bestIntent.Name, out handler))
            {
                handler = this.handlerByIntent[string.Empty];
            }

            if (handler != null)
            {
                await handler(context, item, result);
            }
            else
            {
                var text = $"No default intent handler found.";
                throw new Exception(text);
            }
        }

        protected virtual IDictionary<string, NLPIntentActivityHandler> GetHandlersByIntent()
        {
            return EnumerateHandlers().ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        protected virtual async Task<IDialog<NLPResult>> MakeActionDialog(INLPService service, string contextId, string prompt)
        {
            return new NLPActionDialog(service, contextId, prompt);
        }

        private NLPResult BestResultFrom(IEnumerable<NLPResult> winners)
        {
            return winners.MaxBy(w => w.Intent?.Score ?? 0d);
        }

        private NLPIntent BestIntentFrom(NLPResult result)
        {
            return result.Intent;
        }

        private Task<string> GetQueryTextAsync(IDialogContext context, IMessageActivity message)
        {
            return Task.FromResult(message.Text);
        }


        private IEnumerable<KeyValuePair<string, NLPIntentActivityHandler>> EnumerateHandlers()
        {
            var type = this.GetType();
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var method in methods)
            {
                var intents = method.GetCustomAttributes<NLPIntentAttribute>(inherit: true).ToArray();
                NLPIntentActivityHandler intentHandler = null;

                try
                {
                    intentHandler = (NLPIntentActivityHandler)Delegate.CreateDelegate(typeof(NLPIntentActivityHandler), this, method, throwOnBindFailure: false);
                }
                catch (ArgumentException)
                {
                    // "Cannot bind to the target method because its signature or security transparency is not compatible with that of the delegate type."
                    // https://github.com/Microsoft/BotBuilder/issues/634
                    // https://github.com/Microsoft/BotBuilder/issues/435
                }

                // fall back for compatibility
                if (intentHandler == null)
                {
                    try
                    {
                        var handler = (NLPIntentHandler)Delegate.CreateDelegate(typeof(NLPIntentHandler), this, method, throwOnBindFailure: false);

                        if (handler != null)
                        {
                            // thunk from new to old delegate type
                            intentHandler = (context, message, result) => handler(context, result);
                        }
                    }
                    catch (ArgumentException)
                    {
                        // "Cannot bind to the target method because its signature or security transparency is not compatible with that of the delegate type."
                        // https://github.com/Microsoft/BotBuilder/issues/634
                        // https://github.com/Microsoft/BotBuilder/issues/435
                    }
                }

                if (intentHandler != null)
                {
                    var intentNames = intents.Select(i => i.IntentName).DefaultIfEmpty(method.Name);

                    foreach (var intentName in intentNames)
                    {
                        var key = string.IsNullOrWhiteSpace(intentName) ? string.Empty : intentName;
                        yield return new KeyValuePair<string, NLPIntentActivityHandler>(intentName, intentHandler);
                    }
                }
                else
                {
                    if (intents.Length > 0)
                    {
                        throw new InvalidIntentHandlerException(string.Join(";", intents.Select(i => i.IntentName)), method);
                    }
                }
            }
        }
    }
}
