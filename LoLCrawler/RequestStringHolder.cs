using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler
{
    public static class RequestStringHolder
    {
        //Shared strings for all api calls.
        private static string euRoot = "https://euw1.api.riotgames.com/";
        private static string apiKey = "RGAPI-53e7278a-2924-4abb-8678-25ee3c7d6260";
        private static string apiKeySuffix = $"api_key={apiKey}";

        //Champion-Mastery-V3
        private static string championMasteriesBySummonerId = "lol/champion-mastery/v3/champion-masteries/by-summoner/"; //+SummonerID;
        //variation of the above also exists including additional /by-champion/{championId}.
        private static string championMasteryScoreBySummonerId = "lol/champion-mastery/v3/scores/by-summoner/"; //+SummonerID;

        //League-V3
        private static string challengerLeaguesByQueue = "lol/league/v3/challengerleagues/by-queue/"; //+Queue;
        private static string leagueByLeagueId = "lol/league/v3/leagues/"; //+LeagueId
        private static string masterLeaguesByQueue = "lol/league/v3/masterleagues/by-queue/"; //+Queue;
        private static string leaguePositionsBySummonerId = "lol/league/v3/positions/by-summoner/"; //+summonerId
        //LOL-STATUS-V3
        private static string status = "lol/status/v3/shard-data/"; //region queried by euRoot (could use an NA root to query NA);

        private static string summonerRequest = "lol/summoner/v3/summoners/by-name/"; //+name + ?;
        private static string matchListFromSummonerAccountId = "lol/match/v3/matchlists/by-account/"; //+id + ?;
        private static string matchDetailedFromId = "lol/match/v3/matches/"; //+id + ?

        //LOL-STATUS-V3
        private static string Status()
        {
            return $"{euRoot}{status}?{apiKeySuffix}";
        }


        //Champion-Mastery-V3
        public static string ChampionMasteriesBySummonerId(string summonerId)
        {
            return $"{euRoot}{championMasteriesBySummonerId}{summonerId}?{apiKeySuffix}";
        }
        public static string ChampionMasteriesBySummonerByChampion(string summonerId, string championId)
        {
            return $"{euRoot}{championMasteriesBySummonerId}{summonerId}/by-champion{championId}?{apiKeySuffix}";
        }
        public static string ChampionMasteryScoreBySummonerId(string summonerId)
        {
            return $"{euRoot}{championMasteryScoreBySummonerId}{summonerId}?{apiKeySuffix}";
        }

        //League-V3
        public static string ChallengerLegauesByQueue(string queue)
        {
            return $"{euRoot}{challengerLeaguesByQueue}{queue}?{apiKeySuffix}";
        }
        public static string LeagueByLeagueId(string leagueId)
        {
            return $"{euRoot}{leagueByLeagueId}{leagueId}?{apiKeySuffix}";
        }
        public static string MasterLeaguesByQueue(string queue)
        {
            return $"{euRoot}{masterLeaguesByQueue}{queue}?{apiKeySuffix}";
        }
        public static string LeaguePositionsBySummonerId(string summonerId)
        {
            return $"{euRoot}{leaguePositionsBySummonerId}{summonerId}?{apiKeySuffix}";
        }

        //LOL-STATUS-V3




        //other(to be regrouped according to their api as above, possibly then refactored into their own objects.);
        public static string SummonerRequest(string name)
        {
            return $"{euRoot}{summonerRequest}{name}?{apiKeySuffix}";
        }
        public static string MatchListRequest(string summonerAccountId)
        {
            return $"{euRoot}{matchListFromSummonerAccountId}{summonerAccountId}?{apiKeySuffix}";
        }
        public static string MatchDetailedRequest(string matchId)
        {
            return $"{euRoot}{matchDetailedFromId}{matchId}?{apiKeySuffix}";
        }
        



    }
}
