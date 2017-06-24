using System;
using Atento.NLP.Services.Implementations;
using Microsoft.Bot.Builder.Internals.Fibers;

namespace Atento.NLP.Dialogs
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class NLPServiceAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly NLPServices type;

        // This is a positional argument
        public NLPServiceAttribute(NLPServices type)
        {
            this.type = type;
        }

        public NLPServices Type
        {
            get { return type; }
        }

       
    }
}