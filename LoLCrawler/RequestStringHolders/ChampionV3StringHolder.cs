using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.RequestStringHolders
{
    public class ChampionV3StringHolder
    {
        public ChampionV3StringHolder(SharedStringHolder sharedStringHolder)
        {
            root = sharedStringHolder.Root();
            apiKeySuffix = sharedStringHolder.ApiKeySuffix();
        }

        private string root;
        private string apiKeySuffix;

        private readonly string champions = "lol/platform/v3/champions"; //no additional query paramters;
        //variation of above with Id as parameter.

        public string Champions()
        {
            return $"{root}{champions}?{apiKeySuffix}";
        }
        public string ChampionsById(string id)
        {
            return $"{root}{champions}/{id}?{apiKeySuffix}";
        }
    }
}
