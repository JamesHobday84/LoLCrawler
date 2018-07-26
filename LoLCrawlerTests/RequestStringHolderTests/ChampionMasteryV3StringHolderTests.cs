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
        private readonly string euRoot = "https://euw1.api.riotgames.com";

        [Fact]
        public void CorrectStringForMasteriesBySummonerIdEuWest()
        {
            var sut = new ChampionMasteryV3StringHolder(new EuWestStringHolder());
            var summonerId = "unkownEntity";
            var expected = $"{euRoot}/lol/champion-mastery/v3/champion-masteries/by-summoner/{summonerId}{apiKeySuffix}";

            var result = sut.ChampionMasteriesBySummonerId(summonerId);

            Assert.Equal(result, expected);
        }

        [Fact]
        public void CorrectStringForMasteriesBySummonerIdByChampionEuWest()
        {
            var sut = new ChampionMasteryV3StringHolder(new EuWestStringHolder());
            var summonerId = "60";
            var championId = "10";
            var expected = $"{euRoot}/lol/champion-mastery/v3/champion-masteries/by-summoner/" +
                $"{summonerId}/by-champion/{championId}{apiKeySuffix}";

            var result = sut.ChampionMasteriesBySummonerByChampion(summonerId, championId);

            Assert.Equal(result, expected);
        }
    }
}
