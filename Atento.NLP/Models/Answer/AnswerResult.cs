using Atento.NLP.Services.Interfaces;
using Microsoft.Bot.Builder.Luis.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Atento.NLP.Models.Answer
{
    public class NLPResult
    {

        public NLPResult(IEntityQuery query, INLPService service)
        {
            Intent = new NLPIntent();
            Entities = new List<NLPEntity>();
            Query = query;
            Service = service;
        }

        public NLPIntent Intent { get; set; }

        public List<NLPEntity> Entities { get; set; }



        public IEntityQuery Query { get; private set; }

        public string QueryEntity(string entityName)
        {
            return Query.TryFindEntity(this, entityName);
        }


        public INLPService Service { get; private set; }

        #region Luis Specifics
        [JsonProperty(PropertyName = "dialog")]
        public DialogResponse Dialog { get; set; }
        #endregion
    }
}