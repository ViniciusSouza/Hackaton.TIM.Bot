using Atento.NLP.Models.Answer;
using Atento.NLP.Services.Interfaces;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace Atento.NLP.Services.Implementations
{
    public class LuisEntityQuery : IEntityQuery
    {
        private LuisResult _result;
        public LuisEntityQuery(LuisResult result)
        {
            _result = result;
        }

        public string TryFindEntity(NLPResult result, string entityName)
        {
            EntityRecommendation entityRecommendation;
            _result.TryFindEntity(entityName, out entityRecommendation);
            return entityRecommendation?.Entity ?? string.Empty;
        }
    }
}