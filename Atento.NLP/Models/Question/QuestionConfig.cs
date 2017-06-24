using System.Collections.Generic;

namespace Atento.NLP.Models.Question
{
    public class DialogConfig
    {

        public string NLPApi { get; set; }

        public List<DialogIntent> Intents { get; set; }
    }
}
