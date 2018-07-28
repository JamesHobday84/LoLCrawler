using LoLCrawler.DatabaseEntity;
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
            dbHelper = new DbHelper();
        }
        private RequestStringHolder requestStringHolder;
        private DbHelper dbHelper;

        //Collect summoners from start with a given summoner name then working thorugh the db.
        public void CollectSummoners(string summonerName)
        {
            Summoner summoner = new ApiRequest(requestStringHolder).Summoner.SummonerByName(summonerName);
            if(summoner != null)
            {
                dbHelper.SubmitSummonerIfNotDuplicate(EntityFromRiotDto.GetSummoner(summoner));
                CollectSummoners();
            }
            
        }
        //collect more summoners from existing dbEntries
        public void CollectSummoners() {
            int index = 100;
            int newSummonersFound = 0;
            int totalSummonersFound = 0;
            SummonerEntity summonerEnt = dbHelper.GetSummonerByIndex(index);
            while(summonerEnt != null)
            {
                Console.WriteLine($"Currently on index {index}");
                MatchList matchList = new ApiRequest(requestStringHolder).Match.MatchList(summonerEnt.AccountId);
                foreach(Match match in matchList.matches)
                {
                    MatchDetailed matchDetailed = new ApiRequest(requestStringHolder).Match.Match(match.gameId.ToString());
                    foreach(ParticipantIdentity pId in matchDetailed.participantIdentities)
                    {
                        string summonerName = pId.player.summonerName;
                        Summoner summoner = new ApiRequest(requestStringHolder).Summoner.SummonerByName(summonerName);
                        if (summoner != null)
                        {

                            SummonerEntity possibleNewSummoner = EntityFromRiotDto.GetSummoner(summoner);
                            if (dbHelper.SubmitSummonerIfNotDuplicate(possibleNewSummoner))
                            {
                                newSummonersFound++;
                            }
                            totalSummonersFound++;
                            Console.Clear();
                            Console.WriteLine($"Found {totalSummonersFound} Summoners : {newSummonersFound} New Summoners");
                        }
                    }
                }
                index++;
            }
            
        }
        public void CollectLeagueNames()
        {

        }
    }
}

