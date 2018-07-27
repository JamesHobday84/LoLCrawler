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
        [Fact]
        public void LeaguesReturnsNullWhenIdInvalid()
        {
            var sut = new LeagueV3Request(new LoLCrawler.RequestStringHolder());
            var leagueId = "invalidLeague";

            var result = sut.Leagues(leagueId);

            Assert.Null(result);
        }
        [Fact]
        public void LeaguesReturnsLeagueListWhenIdValid()
        {
            var sut = new LeagueV3Request(new LoLCrawler.RequestStringHolder());
            var leagueId = "ceae57c0-fd51-11e7-825d-c81f66dd0e0d"; //valid league id;

            var result = sut.Leagues(leagueId);

            Assert.NotNull(result);
        }
        [Fact]
        public void MasterLeaguesReturnsNullWhenQueueInvalid()
        {
            var sut = new LeagueV3Request(new LoLCrawler.RequestStringHolder());
            var queue = "invalidQueue";

            var result = sut.MasterLeagues(queue);

            Assert.Null(result);
        }
        [Fact]
        public void MasterLeaguesReturnsLeagueListWhenQueueValid()
        {
            var sut = new LeagueV3Request(new LoLCrawler.RequestStringHolder());
            var queue = "RANKED_SOLO_5x5";

            var result = sut.MasterLeagues(queue);

            Assert.NotNull(result);
        }
        [Fact]
        public void LeaguePositionsReturnsNullWhenIdInvalidOrEnumerableEmpty()
        {
            var sut = new LeagueV3Request(new LoLCrawler.RequestStringHolder());
            var summonerId = "10";

            var result = sut.LeaguePositions(summonerId);

            Assert.Null(result);
        }
        [Fact]
        public void LeaguePositionsReturnsLeaguePositionsWhenIdValidAndEnumerableNotEmpty()
        {
            var sut = new LeagueV3Request(new LoLCrawler.RequestStringHolder());
            var summonerId = "20841022"; //valid league id;

            var result = sut.LeaguePositions(summonerId);

            Assert.NotNull(result);
        }
    }
}
