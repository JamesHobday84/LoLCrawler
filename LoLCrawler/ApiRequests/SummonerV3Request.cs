using RiotData.LoLCrawler;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.ApiRequests
{
    public class SummonerV3Request
    {
        public SummonerV3Request(RequestStringHolder rsh)
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

        public Summoner SummonerByAccountId(string accountId)
        {
            string request = requestStringHolder.Summoner.SummonersByAccountId(accountId);
            string json = null;
            Summoner result = null;

            try
            {
                json = requester.Fetch(request);
                if (json == EXCEEDED_LIMIT)
                {
                    onRateLimitExceeded();
                    return SummonerByAccountId(accountId);
                }
                result = RiotDtoFromJson.GetSummoner(json);
            }
            catch
            {
                Console.WriteLine("Something went wrong in SummonerByAccountId(accountId) : Returning null");
                return null;
            }

            return result;
        }

        public Summoner SummonerByName(string summonerName)
        {
            string request = requestStringHolder.Summoner.SummonersByName(summonerName);
            string json = null;
            Summoner result = null;

            try
            {
                json = requester.Fetch(request);
                if (json == EXCEEDED_LIMIT)
                {
                    onRateLimitExceeded();
                    return SummonerByName(summonerName);
                }
                result = RiotDtoFromJson.GetSummoner(json);
            }
            catch
            {
                Console.WriteLine("Something went wrong in SummonerByName(summonerName) : Returning null");
                return null;
            }

            return result;
        }

        public Summoner SummonerBySummonerId(string summonerId)
        {
            string request = requestStringHolder.Summoner.SummonerBySummonerId(summonerId);
            string json = null;
            Summoner result = null;

            try
            {
                json = requester.Fetch(request);
                if (json == EXCEEDED_LIMIT)
                {
                    onRateLimitExceeded();
                    return SummonerBySummonerId(summonerId);
                }
                result = RiotDtoFromJson.GetSummoner(json);
            }
            catch
            {
                Console.WriteLine("Something went wrong in SummonerBySummonerId(SummonerId) : Returning null");
                return null;
            }

            return result;
        }
    }
}
