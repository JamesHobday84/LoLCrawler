using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler
{
    public static class RequestStringHolder
    {
        private static string euRoot = "https://euw1.api.riotgames.com/";
        private static string apiKey = "RGAPI-53e7278a-2924-4abb-8678-25ee3c7d6260";
        private static string apiKeySuffix = $"api_key={apiKey}";
        private static string summonerRequest = "lol/summoner/v3/summoners/by-name/"; //+name + ?;
        private static string matchListFromSummonerAccountId = "lol/match/v3/matchlists/by-account/"; //+id + ?;
        private static string matchDetailedFromId = "lol/match/v3/matches/"; //+id + ?
        private static string leaguePositionFromSummonerId = "/lol/league/v3/positions/by-summoner/"; //+id + ?;

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
