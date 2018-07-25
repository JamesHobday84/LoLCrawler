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
        public void CollectNamesFromMatchHistory(string summonerName)
        {
            Summoner summoner = new ApiRequest().GetSummonerByName(summonerName);
            Console.WriteLine($"Found Summoner : {summonerName}");

            Console.WriteLine("Attempting to find matchHistory...");
            MatchList matchList = new ApiRequest().GetMatchListBySummonerId(summoner.accountId);
            Console.WriteLine($"Found Match History, gamesRetreived: {matchList.matches.Count} // {matchList.totalGames}");

            Console.WriteLine("Attempting To Retreive Games");


            HashSet<string> nameList = new HashSet<string>();
            int count = 0;
            foreach(Match match in matchList.matches)
            {
                MatchDetailed matchDetailed = new ApiRequest().GetMatchDetailedById(match.gameId.ToString());
                
                foreach (var ParticipantIdentity in matchDetailed.participantIdentities)
                {
                    string name = ParticipantIdentity.player.summonerName;
                    nameList.Add(name);
                }
                count++;
                Console.WriteLine($"Match {count} \\ 100 Complete");
            }

            Console.WriteLine($"Attempting to process and submit {nameList.Count} names");

            DbHelper dbHelper = new DbHelper();
            int uniqureRecordsFound = 0;

            foreach(string name in nameList)
            {
                if(dbHelper.SubmitNameIfUnique(new Name(name)))
                {
                    uniqureRecordsFound++;
                }
            }

            Console.WriteLine($"Submitted {uniqureRecordsFound} new, previously unknown, names");
        }

        public void CollectNamesFromMatchHistory(int index)
        {
            DbHelper dbHelper = new DbHelper();

            while(dbHelper.GetNameFromId(index) != null)
            {
                Name name = dbHelper.GetNameFromId(index);
                CollectNamesFromMatchHistory(name.summonerName);
                Console.WriteLine($"Collected all name from {name.summonerName}'s match history : DbIndex was {index}");
                index++;
            }
        }

        public void CollectLeagueDivsFromDbNames()
        {
            int newRecordsFound = 0;
            int index = 1;
            DbHelper dbHelper = new DbHelper();
            while (dbHelper.GetNameFromId(index) != null)
            {
                Name name = dbHelper.GetNameFromId(index);
                Summoner summoner = new ApiRequest().GetSummonerByName(name.summonerName);
                if (summoner != null)
                {
                    LeaguePosition leaguePosition = new ApiRequest().GetSoloQLeaguePositionBySummonerId(summoner.id);
                    LeagueDiv leagueDiv;
                    if (leaguePosition != null)
                    {
                        leagueDiv = new LeagueDiv
                        {
                            summonerName = summoner.name,
                            tier = leaguePosition.tier,
                            rank = leaguePosition.rank,
                        };
                    }
                    else
                    {
                        leagueDiv = new LeagueDiv(summoner.name);
                    }

                    if (dbHelper.submitLeagueDivIfUnique(leagueDiv))
                    {
                        newRecordsFound++;
                    }
                    Console.WriteLine($"Finished processing index {index} : Total New Records = {newRecordsFound}");
                }
                index++;
            }
        }
    }
}

