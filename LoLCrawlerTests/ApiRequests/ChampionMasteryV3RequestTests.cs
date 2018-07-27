using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using LoLCrawler.ApiRequests;
using LoLCrawler;

namespace LoLCrawlerTests.ApiRequests
{
    public class ChampionMasteryV3RequestTests
    {
        [Fact]
        public void ReturnsNullIfNotFound()
        {
            var sut = new ChampionMasteryV3Request(new RequestStringHolder());
            var summonerId = "123456";

            var result = sut.ChampionMasteries(summonerId);

            Assert.Null(result);
        }
    }
}
