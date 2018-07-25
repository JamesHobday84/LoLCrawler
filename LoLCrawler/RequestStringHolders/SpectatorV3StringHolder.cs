using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.RequestStringHolders
{
    class SpectatorV3StringHolder
    {
        public SpectatorV3StringHolder(SharedStringHolder sharedStringHolder)
        {
            root = sharedStringHolder.Root();
            apiKeySuffix = sharedStringHolder.ApiKeySuffix();
        }

        //Shared request strings.

        private string root;
        private string apiKeySuffix;

        //Api specific request strings.

        private readonly string activeGamesBySummonerId = "lol/spectator/v3/active-games/by-summoner/"; //+SummonerId
        private readonly string featuredGames = "/lol/spectator/v3/featured-games"; //No Query params to append.

        //Assemble request strings...

        public string ActiveGamesBySummonerId(string summonerId)
        {
            return $"{root}{activeGamesBySummonerId}{summonerId}?{apiKeySuffix}";
        }
        public string FeaturedGames()
        {
            return $"{root}{featuredGames}?{apiKeySuffix}";
        }

    }
}
