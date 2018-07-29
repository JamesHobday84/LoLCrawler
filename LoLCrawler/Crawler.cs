using LoLCrawler.DatabaseEntity;
using LoLCrawler.RiotData;
using RiotData.LoLCrawler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
        //collect league information from summonerEntities.
        public void CollectLeagueNames(IEnumerable<SummonerEntity> summonerEntities)
        {
            int summonersQueried = 0;
            int leaguesFound = 0;

            foreach(SummonerEntity summoner in summonerEntities)
            {
                IEnumerable<LeaguePosition> leaguesList = new ApiRequest(requestStringHolder).League.LeaguePositions(summoner.SummonerId);
                if (leaguesList != null)
                {
                    IEnumerable<LeaguePosition> soloQLeague = leaguesList.Where(x => x.queueType == "RANKED_SOLO_5x5");
                    LeaguePosition leaguePos = soloQLeague.FirstOrDefault();
                    LeagueEntity league = EntityFromRiotDto.GetLeague(leaguePos);
                    if (league != null && dbHelper.SubmitLeagueIfNotDuplicate(league))
                    {
                        leaguesFound++;
                    }
                }
                summonersQueried++;
                Console.Clear();
                Console.WriteLine($"{summonersQueried} Summoners From {leaguesFound} Leagues");
            }
        }
        private IEnumerable<Match> last10MatchesOrLess(string accountId)
        {
            MatchList matchList = new ApiRequest(requestStringHolder).Match.MatchList(accountId);
            return matchList.matches.Take(10);    
        }
        private IEnumerable<Summoner> getSummonersFromMatches(IEnumerable<Match> matches)
        {
            Console.WriteLine("Collecting Summoners From Matches.");
            List<Summoner> result = new List<Summoner>();
            foreach (Match match in matches)
            {
                MatchDetailed matchDetailed = new ApiRequest(requestStringHolder).Match.Match(match.gameId.ToString());
                foreach(ParticipantIdentity pId in matchDetailed.participantIdentities)
                {
                    Summoner summoner = new ApiRequest(requestStringHolder).Summoner.SummonerByName(pId.player.summonerName);
                    if(summoner != null)
                    {
                        dbHelper.SubmitSummonerIfNotDuplicate(EntityFromRiotDto.GetSummoner(summoner));
                        result.Add(summoner);
                    }
                }
            }
            return result;
        }
        private LeaguePosition getSoloQLeaguePosition(string summonerId)
        {
            IEnumerable<LeaguePosition> leaguePositions = new ApiRequest(requestStringHolder).League.LeaguePositions(summonerId);
            if(leaguePositions == null)
            {
                return null;
            }
            LeaguePosition leaguePosition = leaguePositions.Where(x => x.queueType == "RANKED_SOLO_5x5").FirstOrDefault();

            return leaguePosition;
        }
        public void CollectLeaguesByTier(string tier)
        {
            int leaguesFound = 0;
            int summonersFound = 0;
            IEnumerable<LeagueEntity> leagues = dbHelper.GetLeaguesByTier(tier);
            foreach (LeagueEntity league in leagues)
            {
                LeagueList leagueList = new ApiRequest(requestStringHolder).League.Leagues(league.LeagueId);
                foreach(LeaguePosition leaguePosition in leagueList.entries)
                {
                    Summoner summoner = new ApiRequest(requestStringHolder).Summoner.SummonerByName(leaguePosition.playerOrTeamName);
                    IEnumerable<Match> matches = last10MatchesOrLess(summoner.accountId);
                    IEnumerable<Summoner> summonerFromMatches = getSummonersFromMatches(matches);
                    foreach(Summoner sum in summonerFromMatches)
                    {
                        LeaguePosition foundPosition = getSoloQLeaguePosition(sum.id);
                        if(foundPosition != null)
                        {
                            if (dbHelper.SubmitLeagueIfNotDuplicate(EntityFromRiotDto.GetLeague(foundPosition)))
                            {
                                leaguesFound++;
                            }
                            summonersFound++;
                        }
                        Console.Clear();
                        Console.WriteLine($"{summonersFound} Summoners Found : {leaguesFound} New Leagues Found");
                    }
                }
            }
        }  
        
    }
}

