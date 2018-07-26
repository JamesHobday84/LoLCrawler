using LoLCrawler;
using LoLCrawler.RequestStringHolders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LoLCrawlerTests.RequestStringHolderTests
{
    public class ChampionMasteryV3StringHolderTests
    {
        private readonly string apiKeySuffix = $"?api_key={ApiKeyHolder.ApiKey}";

        [Fact]
        public void CorrectStringForMasteriesBySummonerIdEuWest()
        {
            var sut = new ChampionMasteryV3StringHolder(new EuWestStringHolder());
            var summonerId = "unkownEntity";
            var expected = "https://euw1.api.riotgames.com/lol/champion-mastery/v3/champion-masteries/by-summoner/" 
                + summonerId + apiKeySuffix;

            var result = sut.ChampionMasteriesBySummonerId(summonerId);

            Assert.Equal(result, expected);
        }
    }
}
