using LoLCrawler.DatabaseEntity;
using LoLCrawler.RiotData;
using RiotData.LoLCrawler;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler
{
    public static class EntityFromRiotDto
    {
        public static SummonerEntity GetSummoner(Summoner summoner)
        {
            SummonerEntity result = new SummonerEntity();
            result.AccountId = summoner.accountId;
            result.Name = summoner.name;
            result.ProfileIconId = summoner.profileIconId;
            result.RevisionDate = summoner.revisionDate;
            result.SummonerId = summoner.id;
            result.SummonerLevel = summoner.summonerLevel;
            return result;
        }

        public static LeagueEntity GetLeague(LeaguePosition leaguePosition)
        {
            LeagueEntity result = new LeagueEntity();
            result.LeagueId = leaguePosition.leagueId;
            result.Name = leaguePosition.leagueName;
            result.Queue = leaguePosition.queueType;
            result.Tier = leaguePosition.tier;
            return result;
        }
    }
}
