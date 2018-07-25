using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.RequestStringHolders
{
    public class EuWestStringHolder : SharedStringHolder
    {
        private readonly string root = "https://euw1.api.riotgames.com/";
        private readonly string apiKey = "RGAPI-53e7278a-2924-4abb-8678-25ee3c7d6260";

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
