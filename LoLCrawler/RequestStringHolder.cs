using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler
{
    public static class RequestStringHolder
    {
        private static string _euRoot = "https://euw1.api.riotgames.com/";
        private static string _apiKey = "RGAPI-5e8ce71c-5bf6-4aff-b9ce-693da992c5de";
        private static string _apiKeySuffix = $"api_key={_apiKey}";
        private static string _summonerRequest = "lol/summoner/v3/summoners/by-name/"; //+name + ?;
        private static string _matchListFromSummonerId = "lol/match/v3/matchlists/by-account/"; //+id + ?;
        private static string _matchDetailedFromId = "lol/match/v3/matches/"; //+id + ?

        public static string SummonerRequest(string name)
        {
            return $"{_euRoot}{_summonerRequest}{name}?{_apiKeySuffix}";
        }
        public static string MatchListRequest(string summonerId)
        {
            return $"{_euRoot}{_matchListFromSummonerId}{summonerId}?{_apiKeySuffix}";
        }
        public static string _MatchDetailedRequest(string matchId)
        {
            return $"{_euRoot}{_matchDetailedFromId}{matchId}?{_apiKeySuffix}";
        }



    }
}
