using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.RequestStringHolders
{
    public class LeagueV3StringHolder
    {
        public LeagueV3StringHolder(SharedStringHolder sharedStringHolder)
        {
            root = sharedStringHolder.Root();
            apiKeySuffix = sharedStringHolder.ApiKeySuffix();
        }

        //Shared request strings.

        private string root;
        private string apiKeySuffix;

        //Api specific request strings

        private readonly string challengerLeaguesByQueue = "lol/league/v3/challengerleagues/by-queue/"; //+Queue;
        private readonly string leagueByLeagueId = "lol/league/v3/leagues/"; //+LeagueId
        private readonly string masterLeaguesByQueue = "lol/league/v3/masterleagues/by-queue/"; //+Queue;
        private readonly string leaguePositionsBySummonerId = "lol/league/v3/positions/by-summoner/"; //+summonerId;


        //Assemble request strings...

        public string ChallengerLegauesByQueue(string queue)
        {
            return $"{root}{challengerLeaguesByQueue}{queue}?{apiKeySuffix}";
        }
        public string LeagueByLeagueId(string leagueId)
        {
            return $"{root}{leagueByLeagueId}{leagueId}?{apiKeySuffix}";
        }
        public string MasterLeaguesByQueue(string queue)
        {
            return $"{root}{masterLeaguesByQueue}{queue}?{apiKeySuffix}";
        }
        public string LeaguePositionsBySummonerId(string summonerId)
        {
            return $"{root}{leaguePositionsBySummonerId}{summonerId}?{apiKeySuffix}";
        }


    }
}
