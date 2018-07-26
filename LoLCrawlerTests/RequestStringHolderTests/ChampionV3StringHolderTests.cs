using System;
using System.Collections.Generic;
using System.Text;
using LoLCrawler;
using LoLCrawler.RequestStringHolders;
using Xunit;

namespace LoLCrawlerTests.RequestStringHolderTests
{
    public class ChampionV3StringHolderTests
    {
        private readonly string apiKeySuffix = $"?api_key={ApiKeyHolder.ApiKey}";
        private readonly string euRoot = "https://euw1.api.riotgames.com";

        [Fact]
        public void CorrectStringForChampionsEuWest()
        {
            var sut = new ChampionV3StringHolder(new EuWestStringHolder());
            var expected = $"{euRoot}/lol/platform/v3/champions{apiKeySuffix}";

            var result = sut.Champions();

            Assert.Equal(result, expected);            
        }

        [Fact]
        public void CorrectStringForChampionsByIdEuWest()
        {
            var sut = new ChampionV3StringHolder(new EuWestStringHolder());
            var id = "10";
            var expected = $"{euRoot}/lol/platform/v3/champions/{id}{apiKeySuffix}";

            var result = sut.ChampionsById(id);

            Assert.Equal(result, expected);
        }
    }
}
