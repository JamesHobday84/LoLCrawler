using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.RequestStringHolders
{
    class LolStatusV3StringHolder
    {
        public LolStatusV3StringHolder(SharedStringHolder sharedStringHolder)
        {
            root = sharedStringHolder.Root();
            apiKeySuffix = sharedStringHolder.ApiKeySuffix();
        }

        //Shared request strings.
        private string root;
        private string apiKeySuffix;

        //Api specific request strings.
        private readonly string status = "lol/status/v3/shard-data/"; //region queried specified by root (could use an NA root to query NA);

        //Assemble request strings...

        public string Status()
        {
            return $"{root}{status}?{apiKeySuffix}";
        }
    }
}
