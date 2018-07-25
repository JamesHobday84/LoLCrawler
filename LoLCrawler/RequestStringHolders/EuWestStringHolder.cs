using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.RequestStringHolders
{
    static class EuWestStringHolder
    {
        private static string euRoot = "https://euw1.api.riotgames.com/";
        private static string apiKey = "RGAPI-53e7278a-2924-4abb-8678-25ee3c7d6260";
        private static string apiKeySuffix = $"api_key={apiKey}";

        public static string EuRoot()
        {
            return euRoot;
        }

        public static string ApiKeySuffix()
        {
            return apiKeySuffix;
        }
    }
}
