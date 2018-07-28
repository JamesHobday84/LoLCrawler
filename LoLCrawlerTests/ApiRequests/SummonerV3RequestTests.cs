using LoLCrawler.ApiRequests;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LoLCrawlerTests.ApiRequests
{
    public class SummonerV3RequestTests
    {
        [Fact]
        public void SummonerByAccountIdReturnsNullIfInValidId()
        {
            var sut = new SummonerV3Request(new LoLCrawler.RequestStringHolder());
            var id = "10";//invalid id should not match any data.

            var result = sut.SummonerByAccountId(id);

            Assert.Null(result);
        }

        [Fact]
        public void SummonerByAccountIdReturnsSummonerIfValidId()
        {
            var sut = new SummonerV3Request(new LoLCrawler.RequestStringHolder());
            var id = "24162553";//valid id should match data.

            var result = sut.SummonerByAccountId(id);

            Assert.NotNull(result);
        }

        [Fact]
        public void SummonerBySummonerIdReturnsNullIfInValidId()
        {
            var sut = new SummonerV3Request(new LoLCrawler.RequestStringHolder());
            var id = "10";//invalid id should not match any data.

            var result = sut.SummonerBySummonerId(id);

            Assert.Null(result);
        }

        [Fact]
        public void SummonerBySummonerIdReturnsSummonerIfValidId()
        {
            var sut = new SummonerV3Request(new LoLCrawler.RequestStringHolder());
            var id = "20841022";//valid id should match data.

            var result = sut.SummonerBySummonerId(id);

            Assert.NotNull(result);
        }

        [Fact]
        public void SummonerByNameReturnsNullIfInValidId()
        {
            var sut = new SummonerV3Request(new LoLCrawler.RequestStringHolder());
            var name = "1ejakdhflaldjvbakdj";//invalid name should not match any data.

            var result = sut.SummonerByName(name);

            Assert.Null(result);
        }

        [Fact]
        public void SummonerByNameReturnsSummonerIfValidId()
        {
            var sut = new SummonerV3Request(new LoLCrawler.RequestStringHolder());
            var name = "unkownentity";//valid name should match data.

            var result = sut.SummonerByName(name);

            Assert.NotNull(result);
        }
    }
}
