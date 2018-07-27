using LoLCrawler;
using LoLCrawler.RequestStringHolders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LoLCrawlerTests.RequestStringHolderTests
{
    public class SummonerV3StringHolderTests
    {
        private readonly string apiKeySuffix = $"?api_key={ApiKeyHolder.ApiKey}";
        private readonly string euRoot = "https://euw1.api.riotgames.com";

        [Fact]
        public void CorrectStringSummonersByAccountId()
        {
            var sut = new SummonerV3StringHolder(new EuWestStringHolder());
            var accountId = "10";
            var expected = $"{euRoot}/lol/summoner/v3/summoners/by-account/{accountId}{apiKeySuffix}";

            var result = sut.SummonersByAccountId(accountId);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CorrectStringSummonersByName()
        {
            var sut = new SummonerV3StringHolder(new EuWestStringHolder());
            var summonerName = "name";
            var expected = $"{euRoot}/lol/summoner/v3/summoners/by-name/{summonerName}{apiKeySuffix}";

            var result = sut.SummonersByName(summonerName);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CorrectStringSummonersBySummonerId()
        {
            var sut = new SummonerV3StringHolder(new EuWestStringHolder());
            var summonerId = "10";
            var expected = $"{euRoot}/lol/summoner/v3/summoners/{summonerId}{apiKeySuffix}";

            var result = sut.SummonerBySummonerId(summonerId);

            Assert.Equal(expected, result);
        }
    }
}
