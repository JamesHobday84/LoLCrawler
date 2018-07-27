using LoLCrawler.RiotData;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.ApiRequests
{
    public class LeagueV3Request
    {
        public LeagueV3Request(RequestStringHolder rsh)
        {
            requestStringHolder = rsh;
        }

        private RequestMaker requester = new RequestMaker();
        private RequestStringHolder requestStringHolder;
        private const string EXCEEDED_LIMIT = "Response status code does not indicate success: 429 (Too Many Requests).";

        private void onRateLimitExceeded()
        {
            Console.WriteLine("Rate Limit Exceeded : Waiting 120 seconds before trying again.");
            System.Threading.Thread.Sleep(120000);
        }

        public LeagueList ChallengerLeagues(string queue)
        {
            string request = requestStringHolder.League.ChallengerLegauesByQueue(queue);
            string json = null;
            LeagueList result = null;

            try
            {
                json = requester.Fetch(request);
                if (json == EXCEEDED_LIMIT)
                {
                    onRateLimitExceeded();
                    return ChallengerLeagues(queue);
                }
                result = RiotDtoFromJson.GetLeagueList(json);
            }
            catch
            {
                Console.WriteLine("Something went wrong in ChallengerLeagues(queue) : Returning null.");
                return null;
            }

            return result;
        }
    }
}
