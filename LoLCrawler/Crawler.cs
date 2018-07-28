using LoLCrawler.RiotData;
using RiotData.LoLCrawler;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler
{
    class Crawler
    {
        public Crawler()
        {
            requestStringHolder = new RequestStringHolder();
        }
        private RequestStringHolder requestStringHolder;

        //Collect summoners from start with a given summoner name then working thorugh the db.
        public void CollectSummoners(string summonerName)
        {
            Summoner summoner = new ApiRequest(requestStringHolder).Summoner.SummonerByName(summonerName);
            //add summoner to db.
            CollectSummoners();
        }
        //collect more summoners from existing dbEntries
        public void CollectSummoners() { }
    }
}

