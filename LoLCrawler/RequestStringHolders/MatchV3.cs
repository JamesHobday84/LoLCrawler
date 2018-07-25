using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.RequestStringHolders
{
    class MatchV3
    {
        public MatchV3(SharedStringHolder sharedStringHolder)
        {
            root = sharedStringHolder.Root();
            apiKeySuffix = sharedStringHolder.ApiKeySuffix();
        }

        //Shared request strings.

        private string root;
        private string apiKeySuffix;

        //Api specific request strings.

        private readonly string matchesByMatchId = "lol/match/v3/matches/"; //+MatchId;
        //There is an additional optional params resulting in the following : lol/match/v3/matches/{matchId}/by-tournament-code/{tournamentCode};
        private readonly string matchListByAccountId = "lol/match/v3/matchlists/by-account/"; //+AccountId;
        private readonly string timelinesByMatchId = "lol/match/v3/timelines/by-match/"; //+MatchId;
        private readonly string matchesByTournamentCode = "lol/match/v3/matches/by-tournament-code/"; //+{TournamentCode} + /ids; (/ids is stringliteral not param);

        //Build request strings...

        public string MatchesByMatchId(string matchId)
        {
            return $"{root}{matchesByMatchId}{matchId}?{apiKeySuffix}";
        }
        public string MatchListByAccountId(string accountId)
        {
            return $"{root}{matchListByAccountId}{accountId}?{apiKeySuffix}";
        }
        public string TimelinesByMatchId(string matchId)
        {
            return $"{root}{timelinesByMatchId}{matchId}?{apiKeySuffix}";
        }
        public string MatchesByTournamentCode(string tournamentCode)
        {
            return $"{root}{matchesByTournamentCode}{tournamentCode}/ids?{apiKeySuffix}";
        }
        public string MatchesByMatchIdByTournamentsCode(string matchId, string tournamentCode)
        {
            return $"{root}{matchesByMatchId}{matchId}/by-tournament-code/{tournamentCode}?{apiKeySuffix}";
        }
    }
}
