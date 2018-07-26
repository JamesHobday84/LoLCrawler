using LoLCrawler;
using LoLCrawler.RequestStringHolders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LoLCrawlerTests.RequestStringHolderTests
{
    public class LeagueV3StringHolderTests
    {
        private readonly string apiKeySuffix = $"?api_key={ApiKeyHolder.ApiKey}";
        private readonly string euRoot = "https://euw1.api.riotgames.com";

        [Fact]
        public void CorrectStringChallengerLeagueByQueueEuWest()
        {
            var sut = new LeagueV3StringHolder(new EuWestStringHolder());
            var queue = "queue";
            var expected = $"{euRoot}/lol/league/v3/challengerleagues/by-queue/{queue}{apiKeySuffix}";

            var result = sut.ChallengerLegauesByQueue(queue);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CorrectStringLeagueById()
        {
            var sut = new LeagueV3StringHolder(new EuWestStringHolder());
            var leagueId = "10";
            var expected = $"{euRoot}/lol/league/v3/leagues/{leagueId}{apiKeySuffix}";

            var result = sut.LeagueByLeagueId(leagueId);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CorrectStringMasterLeaguesByQueue()
        {
            var sut = new LeagueV3StringHolder(new EuWestStringHolder());
            var queue = "queue";
            var expected = $"{euRoot}/lol/league/v3/masterleagues/by-queue/{queue}{apiKeySuffix}";

            var result = sut.MasterLeaguesByQueue(queue);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CorrectStringPositionsBySummonerId()
        {
            var sut = new LeagueV3StringHolder(new EuWestStringHolder());
            var summonerId = "10";
            var expected = $"{euRoot}/lol/league/v3/positions/by-summoner/{summonerId}{apiKeySuffix}";

            var result = sut.LeaguePositionsBySummonerId(summonerId);

            Assert.Equal(expected, result);
        }
    }
}
