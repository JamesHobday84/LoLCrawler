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
            DbDataStatsGather statsGatherer = new DbDataStatsGather();
            statsGatherer.getLeagueDivStats();
            Crawler crawler = new Crawler();
            crawler.CollectNamesFromMatchHistory(1);
            Console.ReadLine();
        }
    }
}
