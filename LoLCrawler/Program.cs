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
            crawler.CollectNamesFromMatchHistory();
            Console.ReadLine();
        }
    }
}
