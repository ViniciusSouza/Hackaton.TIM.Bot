using Atento.NLP.Models.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atento.NLP.Services.Interfaces
{
    public interface INLPService
    {
        Task<NLPResult> QueryAsync(string queryString);
    }
}
