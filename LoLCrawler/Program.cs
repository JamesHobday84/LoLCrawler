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
            Console.ReadLine();
        }
    }
}
