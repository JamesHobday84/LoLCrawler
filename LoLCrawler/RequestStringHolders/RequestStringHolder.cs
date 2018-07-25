﻿using System;
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
        private static string leaguePositionsBySummonerId = "lol/league/v3/positions/by-summoner/"; //+summonerId;
        
        //LOL-STATUS-V3
        private static string status = "lol/status/v3/shard-data/"; //region queried specified by euRoot (could use an NA root to query NA);

        //Match-V3
        private static string matchesByMatchId = "lol/match/v3/matches/"; //+MatchId;
        //There is an addition optional params resulting in the following : lol/match/v3/matches/{matchId}/by-tournament-code/{tournamentCode};
        private static string matchListByAccountId = "lol/match/v3/matchlists/by-account/"; //+AccountId;
        private static string timelinesByMatchId = "lol/match/v3/timelines/by-match/"; //+MatchId;
        private static string matchesByTournamentCode = "lol/match/v3/matches/by-tournament-code/"; //+{TournamentCode} + /ids; (/ids is stringliteral not param);

        //Spectator-V3
        private static string activeGamesBySummonerId = "lol/spectator/v3/active-games/by-summoner/"; //+SummonerId
        private static string featuredGames = "/lol/spectator/v3/featured-games"; //No Query params to append.

        //Summoner-V3
        private static string summonersByAccountId = "lol/summoner/v3/summoners/by-account/"; //+AccountId
        private static string summonersByName = "lol/summoner/v3/summoners/by-name/"; //+SummonerName
        private static string summonersBySummonerId = "lol/summoner/v3/summoners/"; //+SummonerId        


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
        public static string Status()
        {
            return $"{euRoot}{status}?{apiKeySuffix}";
        }

        //Match-V3
        public static string MatchesByMatchId(string matchId)
        {
            return $"{euRoot}{matchesByMatchId}{matchId}?{apiKeySuffix}";
        }
        public static string MatchListByAccountId(string accountId)
        {
            return $"{euRoot}{matchListByAccountId}{accountId}?{apiKeySuffix}";
        }
        public static string TimelinesByMatchId(string matchId)
        {
            return $"{euRoot}{timelinesByMatchId}{matchId}?{apiKeySuffix}";
        }
        public static string MatchesByTournamentCode(string tournamentCode)
        {
            return $"{euRoot}{matchesByTournamentCode}{tournamentCode}/ids?{apiKeySuffix}";
        }
        public static string MatchesByMatchIdByTournamentsCode(string matchId, string tournamentCode)
        {
            return $"{euRoot}{matchesByMatchId}{matchId}/by-tournament-code/{tournamentCode}?{apiKeySuffix}";
        }

        //Spectator-V3
        public static string ActiveGamesBySummonerId(string summonerId)
        {
            return $"{euRoot}{activeGamesBySummonerId}{summonerId}?{apiKeySuffix}";
        }
        public static string FeaturedGames()
        {
            return $"{euRoot}{featuredGames}?{apiKeySuffix}";
        }

        //Summoner-V3
        public static string SummonersByAccountId(string accountId)
        {
            return $"{euRoot}{summonersByAccountId}{accountId}?{apiKeySuffix}";
        }
        public static string SummonersByName(string summonerName)
        {
            return $"{euRoot}{summonersByName}{summonerName}?{apiKeySuffix}";
        }
        public static string SummonerBySummonerId(string summonerId)
        {
            return $"{euRoot}{summonersBySummonerId}{summonerId}?{apiKeySuffix}";
        }
    }
}