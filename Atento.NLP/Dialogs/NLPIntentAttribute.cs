using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Scorables.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atento.NLP.Dialogs
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    [Serializable]
    public sealed class NLPIntentAttribute : AttributeString
    {
        /// <summary>
        /// The LUIS intent name.
        /// </summary>
        public readonly string IntentName;

        /// <summary>
        /// Construct the association between the NLP Service intent and a dialog method.
        /// </summary>
        /// <param name="intentName">The NLP Service intent name.</param>
        public NLPIntentAttribute(string intentName)
        {
            SetField.NotNull(out this.IntentName, nameof(intentName), intentName);
        }

        protected override string Text
        {
            get
            {
                return this.IntentName;
            }
        }
    }
}
