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
            IEnumerable<LeagueEntity> diamondLeagues = context.Leagues.Where(x => x.Tier == "DIAMOND");
            IEnumerable<LeagueEntity> goldLeagues = context.Leagues.Where(x => x.Tier == "GOLD");
            IEnumerable<LeagueEntity> platinumLeagues = context.Leagues.Where(x => x.Tier == "PLATINUM");
            IEnumerable<LeagueEntity> silverLeagues = context.Leagues.Where(x => x.Tier == "SILVER");
            IEnumerable<LeagueEntity> bronzeLeagues = context.Leagues.Where(x => x.Tier == "BRONZE");

            Console.WriteLine($"Diamond Leagues : {diamondLeagues.Count()}");
            Console.WriteLine($"Platinum Leagues : {platinumLeagues.Count()}");
            Console.WriteLine($"Gold Leagues : {goldLeagues.Count()}");
            Console.WriteLine($"Silver Leagues : {silverLeagues.Count()}");
            Console.WriteLine($"Bronze Leagues : {bronzeLeagues.Count()}");

            Crawler crawler = new Crawler();
            crawler.CollectLeaguesByTier("DIAMOND");
            Console.ReadLine();
            crawler.CollectSummoners("unkownEntity");
        }
    }
}
