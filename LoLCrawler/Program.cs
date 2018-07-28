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
            Crawler crawler = new Crawler();
            crawler.CollectLeagueNames();
            Console.ReadLine();
            crawler.CollectSummoners("unkownEntity");
        }
    }
}
