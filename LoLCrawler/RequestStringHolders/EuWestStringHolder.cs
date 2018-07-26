using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.RequestStringHolders
{
    public class EuWestStringHolder : SharedStringHolder
    {
        private readonly string root = "https://euw1.api.riotgames.com/";
        private readonly string apiKey = ApiKeyHolder.ApiKey;

        public string Root()
        {
            return root;
        }

        public string ApiKeySuffix()
        {
            return $"api_key={apiKey}";
        }
    }
}
