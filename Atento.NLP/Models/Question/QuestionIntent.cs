using System.Collections.Generic;

namespace Atento.NLP.Models.Question
{
    public class DialogIntent
    {
        public string Name { get; set; }

        public List<DialogField> Fields { get; set; }

        public List<DialogOutput> Outputs { get; set; }


    }
}