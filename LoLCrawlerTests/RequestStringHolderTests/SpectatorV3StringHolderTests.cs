using LoLCrawler;
using LoLCrawler.RequestStringHolders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LoLCrawlerTests.RequestStringHolderTests
{
    public class SpectatorV3StringHolderTests
    {
        private readonly string apiKeySuffix = $"?api_key={ApiKeyHolder.ApiKey}";
        private readonly string euRoot = "https://euw1.api.riotgames.com";

        [Fact]
        public void CorrectStringActiveGamesBySummonerId()
        {
            var sut = new SpectatorV3StringHolder(new EuWestStringHolder());
            var summonerId = "10";
            var expected = $"{euRoot}/lol/spectator/v3/active-games/by-summoner/{summonerId}{apiKeySuffix}";

            var result = sut.ActiveGamesBySummonerId(summonerId);

            Assert.Equal(expected, result);
        }
    }
}
