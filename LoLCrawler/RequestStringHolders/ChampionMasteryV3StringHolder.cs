using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.RequestStringHolders
{
    public class ChampionMasteryV3StringHolder
    {
        public ChampionMasteryV3StringHolder(SharedStringHolder sharedStringHolder)
        {
            root = sharedStringHolder.Root();
            apiKeySuffix = sharedStringHolder.ApiKeySuffix();
        }

        //Shared request strings.

        private string root;
        private string apiKeySuffix;

        //Api specific request strings.

        private readonly string championMasteriesBySummonerId = "lol/champion-mastery/v3/champion-masteries/by-summoner/"; //+SummonerID;
        //variation of the above also exists including additional /by-champion/{championId}.
        private readonly string championMasteryScoreBySummonerId = "lol/champion-mastery/v3/scores/by-summoner/"; //+SummonerID;
        
        //Assemble request strings...

        public string ChampionMasteriesBySummonerId(string summonerId)
        {
            return $"{root}{championMasteriesBySummonerId}{summonerId}?{apiKeySuffix}";
        }
        public string ChampionMasteriesBySummonerByChampion(string summonerId, string championId)
        {
            return $"{root}{championMasteriesBySummonerId}{summonerId}/by-champion/{championId}?{apiKeySuffix}";
        }
        public string ChampionMasteryScoreBySummonerId(string summonerId)
        {
            return $"{root}{championMasteryScoreBySummonerId}{summonerId}?{apiKeySuffix}";
        }
    }
}
