using LoLCrawler;
using LoLCrawler.ApiRequests;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LoLCrawlerTests.ApiRequests
{
    public class MatchV3RequestTests
    {
        [Fact]
        public void MatchReturnsNullIfInvalidId()
        {
            var sut = new MatchV3Request(new RequestStringHolder());
            var matchId = "10";

            var result = sut.Match(matchId);

            Assert.Null(result);
        }
        [Fact]
        public void MatchReturnsMatchIfIdValid()
        {
            var sut = new MatchV3Request(new RequestStringHolder());
            var matchId = "3715147769";//valid matchId;

            var result = sut.Match(matchId);

            Assert.NotNull(result);
        }
        [Fact]
        public void MatchListReturnsNullIfIdInvalid()
        {
            var sut = new MatchV3Request(new RequestStringHolder());
            var accountId = "10";

            var result = sut.Match(accountId);

            Assert.Null(result);
        }
        [Fact]
        public void MatchListReturnsMatchListIfIdValid()
        {
            var sut = new MatchV3Request(new RequestStringHolder());
            var accountId = "24162553";//Valid accountId;

            var result = sut.MatchList(accountId);

            Assert.NotNull(result);
        }
        
    }
}
