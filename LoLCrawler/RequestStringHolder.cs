using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler
{
    public static class RequestStringHolder
    {
        private static string euRoot = "https://euw1.api.riotgames.com/";
        private static string apiKey = "RGAPI-5e8ce71c-5bf6-4aff-b9ce-693da992c5de";
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
        public static string _MatchDetailedRequest(string matchId)
        {
            return $"{euRoot}{matchDetailedFromId}{matchId}?{apiKeySuffix}";
        }



    }
}
