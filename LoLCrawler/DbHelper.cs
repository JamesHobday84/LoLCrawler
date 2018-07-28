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
                return true;
            }
            return false;
        }
    }
}
