using LoLCrawler.RequestStringHolders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LoLCrawlerTests.RequestStringHolderTests
{
    public class ChampionMasteryV3StringHolderTests
    {
        public void MasteriesBySummonerIdEuWest()
        {
            var sut = new ChampionMasteryV3StringHolder(new EuWestStringHolder());
            var expected = "https://euw1.api.riotgames.com/lol/champion-mastery/v3/champion-masteries/by-summoner/";




        }
    }
}
