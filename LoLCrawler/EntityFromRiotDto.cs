using LoLCrawler.DatabaseEntity;
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
    }
}
