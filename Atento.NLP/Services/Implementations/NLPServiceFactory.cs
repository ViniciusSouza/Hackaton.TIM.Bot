using Atento.NLP.Services.Implementations;
using Atento.NLP.Services.Interfaces;
using System;
using System.Configuration;

namespace Atento.NLP.Services.Implementations
{
    public class NLPServiceFactory
    {
        
        public static INLPService Create(string key)
        {
            var nlpService = (NLPServices)Enum.Parse(typeof(NLPServices), ConfigurationManager.AppSettings[key].ToString());

            return Create(nlpService);


        }


        public static INLPService Create(NLPServices nlpService)
        {

            switch (nlpService)
            {
                case NLPServices.Luis:
                    return new LuisService(
                        ConfigurationManager.AppSettings["LuisModelId"].ToString(),
                        ConfigurationManager.AppSettings["LuisSubscriptionKey"].ToString());
                case NLPServices.Watson:
                    return new WatsonService(
                        ConfigurationManager.AppSettings["WatsonWorkspaceId"].ToString(),
                        ConfigurationManager.AppSettings["WatsonUserPassword"].ToString());
                default:
                    throw new Exception("Invalid NLP Service");
            }


        }
    }


    public enum NLPServices
    {
        Luis,
        Watson
    }
}