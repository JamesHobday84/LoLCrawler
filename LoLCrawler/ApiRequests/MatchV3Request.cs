using RiotData.LoLCrawler;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.ApiRequests
{
    public class MatchV3Request
    {
        public MatchV3Request(RequestStringHolder rsh)
        {
            requestStringHolder = rsh;
        }

        private RequestStringHolder requestStringHolder;
        private RequestMaker requester = new RequestMaker();
        private const string EXCEEDED_LIMIT = "Response status code does not indicate success: 429 (Too Many Requests).";

        private void onRateLimitExceeded()
        {
            Console.WriteLine("Rate Limit Exceeded : Waiting 120 seconds before trying again.");
            System.Threading.Thread.Sleep(120000);
        }

        public MatchDetailed Match(string matchId)
        {
            string request = requestStringHolder.Match.MatchesByMatchId(matchId);
            string json = null;
            MatchDetailed result = null;

            try
            {
                json = requester.Fetch(request);
                if (json == EXCEEDED_LIMIT)
                {
                    onRateLimitExceeded();
                    return Match(matchId);
                }
                result = RiotDtoFromJson.GetMatchDetailed(json);
            }
            catch
            {
                Console.WriteLine("Something went wrong in Match(matchId) : Returning null");
                return null;
            }

            return result; 
        }

        public MatchList MatchList(string accountId)
        {
            string request = requestStringHolder.Match.MatchListByAccountId(accountId);
            string json = null;
            MatchList result = null;

            try
            {
                json = requester.Fetch(request);
                if (json == EXCEEDED_LIMIT)
                {
                    onRateLimitExceeded();
                    return MatchList(accountId);
                }
                result = RiotDtoFromJson.GetMatchList(json);
            }
            catch
            {
                Console.WriteLine("Something went wrong in MatchList(accountId) : Returning null");
                return null;
            }

            return result;
        }
    }
}
