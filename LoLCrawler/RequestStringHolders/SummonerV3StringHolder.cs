using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.RequestStringHolders
{
    public class SummonerV3StringHolder
    {
        public SummonerV3StringHolder(SharedStringHolder sharedStringHolder)
        {
            root = sharedStringHolder.Root();
            apiKeySuffix = sharedStringHolder.ApiKeySuffix();
        }

        //Shared request strings.
        string root;
        string apiKeySuffix;

        //Api specific request strings

        private readonly string summonersByAccountId = "lol/summoner/v3/summoners/by-account/"; //+AccountId
        private readonly string summonersByName = "lol/summoner/v3/summoners/by-name/"; //+SummonerName
        private readonly string summonersBySummonerId = "lol/summoner/v3/summoners/"; //+SummonerId

        //Assemble api request strings...

        public string SummonersByAccountId(string accountId)
        {
            return $"{root}{summonersByAccountId}{accountId}?{apiKeySuffix}";
        }
        public string SummonersByName(string summonerName)
        {
            return $"{root}{summonersByName}{summonerName}?{apiKeySuffix}";
        }
        public string SummonerBySummonerId(string summonerId)
        {
            return $"{root}{summonersBySummonerId}{summonerId}?{apiKeySuffix}";
        }
    }
}
