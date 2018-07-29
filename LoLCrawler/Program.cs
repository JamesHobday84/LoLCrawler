using LoLCrawler.DatabaseEntity;
using LoLCrawler.RiotData;
using RiotData.LoLCrawler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoLCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            //print out all laegue names.
            NamesDbContext context = new NamesDbContext();
            IEnumerable<LeagueEntity> leagues = context.Leagues.OrderBy(x => x.Tier);
            foreach(LeagueEntity league in leagues)
            {
                Console.WriteLine($"{league.Name} : {league.Tier}");
            }
            Crawler crawler = new Crawler();
            crawler.CollectLeagueNames();
            Console.ReadLine();
            crawler.CollectSummoners("unkownEntity");
        }
    }
}
