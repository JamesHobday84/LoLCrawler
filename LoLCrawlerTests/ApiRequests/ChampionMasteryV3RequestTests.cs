﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using LoLCrawler.ApiRequests;
using LoLCrawler;
using System.Linq;

namespace LoLCrawlerTests.ApiRequests
{
    public class ChampionMasteryV3RequestTests
    {
        [Fact]
        public void ChampionMasteriesReturnsNullIfNotFoundOrEmpty()
        {
            var sut = new ChampionMasteryV3Request(new RequestStringHolder());
            var summonerId = "123456"; //Madeup id that shouldn't match any data.

            var result = sut.ChampionMasteries(summonerId);

            Assert.Null(result);
        }
        [Fact]
        public void ChampionMasteriesReturnsNonEmptyIEnumerableIfFoundAndNotEmpty()
        {
            var sut = new ChampionMasteryV3Request(new RequestStringHolder());
            var summonerId = "20841022";//valid id that should correspond to actual data.

            var result = sut.ChampionMasteries(summonerId);

            Assert.True(result.Any());
        }
        /*
        //The below test will take at least 2mins to run as this is how long it takes to 
        //have the limit reset.
        //Has been commented out as it arguably not a unit test and if implementing this test for each riot api
        //would add atleast 14mins to each test run. perhaps create a file of just tests checking rate lmit exceeded behaviour
        //is correct. This may allow it to be reduced to just 2 mins(exceed rate limit once then run all tests as opposed to exceeding
        //the limit once for each test.
        /*
        [Fact]
        public void ChampionMasteriesReturnsSuccessfullyAfterWaitWhenLimitExceeded()
        {
            var sut = new ChampionMasteryV3Request(new RequestStringHolder());
            var summonerId = "20841022";//valid id that should correspond to actual data.
            var limitExceeded = "Response status code does not indicate success: 429 (Too Many Requests).";
            var response = "";
            var requestMaker = new RequestMaker();
            var request = new RequestStringHolder().ChampionMastery.ChampionMasteriesBySummonerId(summonerId);
            var requestsMade = 0;

            //make requests untill limit is exceeded
            while (limitExceeded != response)
            {
                response = requestMaker.Fetch(request);
                requestsMade++;
            }
            var result = sut.ChampionMasteries(summonerId);

            Assert.True(result.Any());
        }
        */

        [Fact]
        public void ChampionMasteryReturnsNullIfNotFound()
        {
            var sut = new ChampionMasteryV3Request(new RequestStringHolder());
            var summonerId = "10";//made up invalid id that should not match any data.
            var championId = "10";

            var result = sut.ChampionMastery(summonerId, championId);

            Assert.Null(result);
        }

        [Fact]
        public void ChampionMasteryReturnsChampionMasteryIfFound()
        {
            var sut = new ChampionMasteryV3Request(new RequestStringHolder());
            var summonerId = "20841022";//valid id that should correspond to actual data.
            var championId = "105";//valid id.

            var result = sut.ChampionMastery(summonerId, championId);

            Assert.NotNull(result);
        }

        [Fact]
        public void ChampionMasteryScoreReturnsZeroIfNotFound()
        {
            var sut = new ChampionMasteryV3Request(new RequestStringHolder());
            var summonerId = "10";

            var result = sut.ChampionMasteryScore(summonerId);

            Assert.Equal(0, result);
        }
        [Fact]
        public void ChampionMasteryScoreReturnsNonZeroWhenNonZeroValue() {

            var sut = new ChampionMasteryV3Request(new RequestStringHolder());
            var summonerId = "20841022";

            var result = sut.ChampionMasteryScore(summonerId);

            Assert.NotEqual(0, result);
        }


    }
}
