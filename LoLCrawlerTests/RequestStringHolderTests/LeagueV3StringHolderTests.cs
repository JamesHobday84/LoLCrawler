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
    }
}
