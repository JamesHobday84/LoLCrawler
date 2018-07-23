using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler
{
    public static class RequestStringHolder
    {
        private static string euRoot = "https://euw1.api.riotgames.com/";
        private static string apiKey = "RGAPI-e04a4915-be08-433c-aba5-cd72fca675c4";
        private static string apiKeySuffix = $"api_key={apiKey}";
        private static string summonerRequest = "lol/summoner/v3/summoners/by-name/"; //+name + ?;
        private static string matchListFromSummonerId = "lol/match/v3/matchlists/by-account/"; //+id + ?;
        private static string matchDetailedFromId = "lol/match/v3/matches/"; //+id + ?

        public static string SummonerRequest(string name)
        {
            return $"{euRoot}{summonerRequest}{name}?{apiKeySuffix}";
        }
        public static string MatchListRequest(string summonerAccountId)
        {
            return $"{euRoot}{matchListFromSummonerId}{summonerAccountId}?{apiKeySuffix}";
        }
        public static string MatchDetailedRequest(string matchId)
        {
            return $"{euRoot}{matchDetailedFromId}{matchId}?{apiKeySuffix}";
        }



    }
}
