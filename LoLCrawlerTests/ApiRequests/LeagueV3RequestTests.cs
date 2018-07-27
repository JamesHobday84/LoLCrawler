using LoLCrawler.ApiRequests;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LoLCrawlerTests.ApiRequests
{
    public class LeagueV3RequestTests
    {
        [Fact]
        public void ChallengerLeaguesReturnsNullWhenQueueInvalid()
        {
            var sut = new LeagueV3Request(new LoLCrawler.RequestStringHolder());
            var queue = "invalidQueue";

            var result = sut.ChallengerLeagues(queue);

            Assert.Null(result);
        }
        [Fact]
        public void ChallengerLeaguesReturnsLeagueListWhenQueueValid()
        {
            var sut = new LeagueV3Request(new LoLCrawler.RequestStringHolder());
            var queue = "RANKED_SOLO_5x5";

            var result = sut.ChallengerLeagues(queue);

            Assert.NotNull(result);
        }
    }
}
