using LoLCrawler.RiotData;
using Newtonsoft.Json;
using RiotData.LoLCrawler;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler
{
    class ApiRequest
    {
        private int _consecutiveFailures = 0;
        private int _consecutiveNullsReturned = 0;
        private const string EXCEEDED_LIMIT = "Response status code does not indicate success: 429 (Too Many Requests).";

        private RequestMaker requester = new RequestMaker();

        private void onRateLimitExceeded()
        {
            Console.WriteLine("Rate Limit Exceeded : WAITING 60 SECONDS");
            _consecutiveFailures++;
            System.Threading.Thread.Sleep(60000);
        }
        private void onRequestSuccess()
        {
            _consecutiveNullsReturned = 0;
            _consecutiveFailures = 0;
        }
        private void onOther()
        {
            _consecutiveNullsReturned++;
            if (_consecutiveNullsReturned > 10)
            {
                //something has gone wrong lets stop.
                throw new Exception();
            }
        }

        public Summoner GetSummonerByName(string name)
        {
            Summoner result = null;
            string json = null;
            try
            {
                json = requester.Fetch(RequestStringHolder.SummonerRequest(name));
                result = RiotDtoFromJson.GetSummoner(json);
            }
            catch
            {
                if (json == EXCEEDED_LIMIT)
                {
                    onRateLimitExceeded();
                    return GetSummonerByName(name);
                }
                else
                {
                    onOther();
                    return null;
                }
            }

            return result;
        }

        public MatchList GetMatchListBySummonerId(string id)
        {
            MatchList result = null;
            string json = null;

            try
            {
                json = requester.Fetch(RequestStringHolder.MatchListByAccountId(id));
                result = RiotDtoFromJson.GetMatchList(json);
            }
            catch
            {
                if (json == EXCEEDED_LIMIT)
                {
                    onRateLimitExceeded();
                    return GetMatchListBySummonerId(id);
                }
                else
                {
                    onOther();
                    return null;
                }
            }
            return result;
        }

        public MatchDetailed GetMatchDetailedById(string id)
        {
            MatchDetailed result = null;
            string json = null;

            try
            {
                json = requester.Fetch(RequestStringHolder.MatchesByMatchId(id));
                result = RiotDtoFromJson.GetMatchDetailed(json);
            }
            catch
            {
                if (json == EXCEEDED_LIMIT)
                {
                    onRateLimitExceeded();
                    return GetMatchDetailedById(id);
                }
                else
                {
                    onOther();
                    return null;
                }
            }
            return result;
        }
        //returns null if not found or no rank data indicating they are unranked.
        public LeaguePosition GetSoloQLeaguePositionBySummonerId(string id)
        {
            IEnumerable<LeaguePosition> leaguePositionList = GetLeaguePositionsBySummonerId(id);
            if (leaguePositionList != null)
            {
                foreach(LeaguePosition leaguePosition in leaguePositionList)
                {
                    if (leaguePosition.queueType == "RANKED_SOLO_5x5")
                    {
                        return leaguePosition;
                    }
                }
            }
            return null;
        }

        public IEnumerable<LeaguePosition> GetLeaguePositionsBySummonerId(string id)
        {
            string json = null;
            IEnumerable<LeaguePosition> result = null;

            try
            {
                json = requester.Fetch(RequestStringHolder.LeaguePositionsBySummonerId(id));
                result = RiotDtoFromJson.GetLeaguePositionList(json);
            }
            catch
            {
                if (json == EXCEEDED_LIMIT)
                {
                    onRateLimitExceeded();
                    return GetLeaguePositionsBySummonerId(id);
                }
                else
                {
                    onOther();
                    return null;
                }
            }

            return result;
        }
    }
}
