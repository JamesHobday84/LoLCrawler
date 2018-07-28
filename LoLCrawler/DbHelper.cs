using LoLCrawler.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLCrawler
{
    public class DbHelper
    {
        NamesDbContext context = new NamesDbContext();
        //rteurns true if already exists.
        private bool summonerAlreadyExists(SummonerEntity summoner)
        {
            var queryResult = context.Summoners.Where(x => x.Name == summoner.Name).SingleOrDefault();
            return (queryResult != null);
        }
        public bool SubmitSummonerIfNotDuplicate(SummonerEntity summoner)
        {
            if (!summonerAlreadyExists(summoner))
            {
                context.Add(summoner);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public SummonerEntity GetSummonerByIndex(int index)
        {
            return context.Summoners.Where(x => x.SummonerEntityId == index).SingleOrDefault();
        }
        public IEnumerable<SummonerEntity> GetAllSummoners()
        {
            return context.Summoners.OrderBy(x => x.Name);
        }
        //returns true if league already exists in db. 
        private bool leagueAlreadyExists(LeagueEntity league)
        {
            var queryResult = context.Leagues.Where(x => x.LeagueId == league.LeagueId).SingleOrDefault();
            return (queryResult != null);
        }
        public bool submitLeagueIfNotDuplicate(LeagueEntity league)
        {
            if (!leagueAlreadyExists(league))
            {
                context.Add(league);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
