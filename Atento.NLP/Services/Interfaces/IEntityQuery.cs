using Atento.NLP.Models.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atento.NLP.Services.Interfaces
{
    public interface IEntityQuery
    {
        string TryFindEntity(NLPResult result, string entityName);

    }
}