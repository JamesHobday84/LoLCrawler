using LoLCrawler;
using LoLCrawler.ApiRequests;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LoLCrawlerTests.ApiRequests
{
    public class ChampionV3RequestTests
    {
        [Fact]
        public void ChampionsDoesNotReturnNull()
        {
            var sut = new ChampionV3Request(new RequestStringHolder());

            var result = sut.Champions();

            Assert.NotNull(result);
        }

        [Fact]
        public void ChampionByIdReturnNullIfNotFound()
        {
            var sut = new ChampionV3Request(new RequestStringHolder());
            var championId = "400000000";//should not match a champion;

            var result = sut.Champion(championId);

            Assert.Null(result);
        }

        [Fact]
        public void ChampionByIdReturnChampionIfFound()
        {
            var sut = new ChampionV3Request(new RequestStringHolder());
            var championId = "105";//should match a champion;

            var result = sut.Champion(championId);

            Assert.NotNull(result);
        }
    }
}
