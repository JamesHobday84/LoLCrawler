using RiotData.LoLCrawler;
using System;

namespace LoLCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Summoner test = new ApiRequest().getSummonerByName("unkownEntity");
            Console.WriteLine(test.name);
            MatchList matchList = new ApiRequest().GetMatchListBySummonerId(test.accountId);
            Console.WriteLine(matchList.matches.Count);
            Console.ReadLine();
        }
    }
}
