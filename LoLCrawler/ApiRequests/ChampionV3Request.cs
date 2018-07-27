using LoLCrawler.RiotData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LoLCrawler.ApiRequests
{
    public class ChampionV3Request
    {

        public ChampionV3Request()
        {
            requestStringHolder = new RequestStringHolder();
        }

        private RequestMaker requester = new RequestMaker();
        private RequestStringHolder requestStringHolder;
        private const string EXCEEDED_LIMIT = "Response status code does not indicate success: 429 (Too Many Requests).";

        private void onRateLimitExceeded()
        {
            Console.WriteLine("Rate Limit Exceeded : Waiting 120 seconds before trying again.");
            System.Threading.Thread.Sleep(120000);
        }

        public IEnumerable<Champion> Champions()
        {
            string request = requestStringHolder.Champion.Champions();
            string json = null;
            IEnumerable<Champion> result = null;

            try
            {
                json = requester.Fetch(request);
                if(json == EXCEEDED_LIMIT)
                {
                    onRateLimitExceeded();
                    return Champions();
                }
                result = RiotDtoFromJson.GetChampionsList(json);
            }
            catch
            {
                Console.WriteLine("Something went wrong in Champions() : returning null");
                return null;
            }

            //return null if empty IEnumerable
            if (!result.Any())
            {
                return null;
            }

            return result;
        }

        public Champion Champion(string id)
        {
            string request = requestStringHolder.Champion.ChampionsById(id);
            string json = null;
            Champion result = null;

            try
            {
                json = requester.Fetch(request);
                if(json == EXCEEDED_LIMIT)
                {
                    onRateLimitExceeded();
                    return Champion(id);
                }
                result = RiotDtoFromJson.GetChampion(json);
            }
            catch
            {
                Console.WriteLine("Something went wrong in Champion(id) : returning null");
                return null;
            }

            return result;
        }
    }
}
