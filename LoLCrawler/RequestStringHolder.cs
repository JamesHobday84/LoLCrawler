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
        //There is also another variation of the above string to get by champion id for a given summoner.
        //lol/champion-mastery/v3/champion-masteries/by-summoner/{summonerId}/by-champion/{championId}.
        //This will be built in the public method returning this as adding a string containging just /by-champion is worthwhile. 
        private static string championMasteryScoreBySummonerId = "lol/champion-mastery/v3/scores/by-summoner/"; //+SummonerID;

        private static string summonerRequest = "lol/summoner/v3/summoners/by-name/"; //+name + ?;
        private static string matchListFromSummonerAccountId = "lol/match/v3/matchlists/by-account/"; //+id + ?;
        private static string matchDetailedFromId = "lol/match/v3/matches/"; //+id + ?
        private static string leaguePositionFromSummonerId = "/lol/league/v3/positions/by-summoner/"; //+id + ?;


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
        public static string LeaguePositionRequest(string summonerId)
        {
            return $"{euRoot}{leaguePositionFromSummonerId}{summonerId}?{apiKeySuffix}";
        }



    }
}
