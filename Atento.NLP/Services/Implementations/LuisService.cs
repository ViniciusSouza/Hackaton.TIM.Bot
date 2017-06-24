using Atento.NLP.Models.Answer;
using Atento.NLP.Services.Interfaces;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Atento.NLP.Services.Implementations
{
    [Serializable]
    public class LuisService : INLPService
    {
        private string _modelId, _subscriptionKey;
        private LuisModelAttribute _model;
        public LuisService(string modelId, string subscriptionKey)
        {
            _modelId = modelId;
            _subscriptionKey = subscriptionKey;
            _model = new LuisModelAttribute(_modelId, _subscriptionKey);
        }


         

        public async Task<NLPResult> QueryAsync(string queryString)
        {
            // TODO: Param
          
            var luisService = new Microsoft.Bot.Builder.Luis.LuisService(_model);

            LuisResult luisResult = await luisService.QueryAsync(queryString.ToString(),
                new System.Threading.CancellationToken());
            
            IntentRecommendation luisIntent = luisResult.TopScoringIntent;
            NLPResult nlpResult = new NLPResult(new LuisEntityQuery(luisResult), this);

            if (luisIntent != null)
            {
                
                nlpResult.Intent.Name = luisIntent.Intent;
                nlpResult.Intent.Score = luisIntent.Score;

                foreach (EntityRecommendation luisEntity in luisResult.Entities)
                {
                    nlpResult.Entities.Add(new NLPEntity { Name = luisEntity.Type, Value = luisEntity.Entity, Score = luisEntity.Score });
                }
            }

            return nlpResult;
        }

        internal async Task<NLPResult> QueryAsync(LuisRequest luisRequest)
        {
           
            string json;
            var uri = luisRequest.BuildUri(_model);
            using (var client = new HttpClient())
            using (var response = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead, CancellationToken.None))
            {
                response.EnsureSuccessStatusCode();
                json = await response.Content.ReadAsStringAsync();
            }

            try
            {
                var result = JsonConvert.DeserializeObject<LuisResult>(json);
                // fix up Luis result for backward compatibility
                // v2 api is not returning list of intents if verbose query parameter 
                // is not set. This will move IntentRecommendation in TopScoringIntent
                // to list of Intents.
                if (result.TopScoringIntent != null && result.Intents == null)
                {
                    result.Intents = new List<IntentRecommendation> { result.TopScoringIntent };
                }
                return new NLPResult(new LuisEntityQuery(result), this);
            }
            catch (JsonException ex)
            {
                throw new ArgumentException("Unable to deserialize the LUIS response.", ex);
            }

        }
    }
}