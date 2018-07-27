using LoLCrawler.RiotData;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.ApiRequests
{
    class ChampionMasteryV3Request
    {

        public ChampionMasteryV3Request(RequestStringHolder rsh)
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

        public IEnumerable<ChampionMastery> ChampionMasteries(string summonerId)
        {
            string request = requestStringHolder.ChampionMastery.ChampionMasteriesBySummonerId(summonerId);
            string json = null;
            IEnumerable<ChampionMastery> result = null;

            try
            {
                json = requester.Fetch(request);
                if (json == EXCEEDED_LIMIT)
                {
                    onRateLimitExceeded();
                    return this.ChampionMasteries(summonerId);
                }
                result = RiotDtoFromJson.GetChampionMasteryList(json);
            }
            catch
            {
                Console.WriteLine($"Something went wrong in (ChampionMasteries({summonerId}) : returning null");
                return null;//something went wrong
            }

            return result;
        }
    }
}
