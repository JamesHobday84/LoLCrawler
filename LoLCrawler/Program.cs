using RiotData.LoLCrawler;
using System;
using System.Collections.Generic;

namespace LoLCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Summoner test = new ApiRequest().GetSummonerByName("unkownEntity");
            Console.WriteLine($"Name : {test.name}");
            MatchList matchList = new ApiRequest().GetMatchListBySummonerId(test.accountId);
            Console.WriteLine($"Retreived {matchList.matches.Count} of {matchList.totalGames} Games");
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
            Console.ReadLine();

        }
    }
}
