using Atento.NLP.Models.Answer;
using Atento.NLP.Services.Interfaces;
using System.Linq;
namespace Atento.NLP.Services.Implementations
{
    internal class WatsonEntityQuery : IEntityQuery
    {
        

        public string TryFindEntity(NLPResult result, string entityName)
        {
            var entity = result.Entities.FirstOrDefault(x => x.Name == entityName);
            return entity?.Value ?? string.Empty;
        }
    }
}