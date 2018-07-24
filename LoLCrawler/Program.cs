using LoLCrawler.RiotData;
using RiotData.LoLCrawler;
using System;
using System.Collections.Generic;

namespace LoLCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Summoner summoner = new ApiRequest().GetSummonerByName("unkownEntity");
            LeaguePosition leaguePosition = new ApiRequest().GetSoloQLeaguePositionBySummonerId(summoner.id);
            Crawler crawler = new Crawler();
            crawler.CollectNamesFromMatchHistory();
            Console.ReadLine();
        }
    }
}
