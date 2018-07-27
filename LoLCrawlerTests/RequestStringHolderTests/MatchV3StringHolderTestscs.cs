using LoLCrawler;
using LoLCrawler.RequestStringHolders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace LoLCrawlerTests.RequestStringHolderTests
{
    public class MatchV3StringHolderTests
    {
        private readonly string apiKeySuffix = $"?api_key={ApiKeyHolder.ApiKey}";
        private readonly string euRoot = "https://euw1.api.riotgames.com";

        [Fact]
        public void CorrectStringMatchesById()
        {
            var sut = new MatchV3StringHolder(new EuWestStringHolder());
            var matchId = "10";
            var expected = $"{euRoot}/lol/match/v3/matches/{matchId}{apiKeySuffix}";

            var result = sut.MatchesByMatchId(matchId);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CorrectStringMatchlistByAccountId()
        {
            var sut = new MatchV3StringHolder(new EuWestStringHolder());
            var accountId = "10";
            var expected = $"{euRoot}/lol/match/v3/matchlists/by-account/{accountId}{apiKeySuffix}";

            var result = sut.MatchListByAccountId(accountId);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CorrectStringTimelineByMatchId()
        {
            var sut = new MatchV3StringHolder(new EuWestStringHolder());
            var matchId = "10";
            var expected = $"{euRoot}/lol/match/v3/timelines/by-match/{matchId}{apiKeySuffix}";

            var result = sut.TimelinesByMatchId(matchId);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CorrectStringMatchesByTournamentCode()
        {
            var sut = new MatchV3StringHolder(new EuWestStringHolder());
            var tournamentCode = "10";
            var expected = $"{euRoot}/lol/match/v3/matches/by-tournament-code/{tournamentCode}/ids{apiKeySuffix}";

            var result = sut.MatchesByTournamentCode(tournamentCode);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CorrectStringMatchesByMatchIdByTournamentCode()
        {
            var sut = new MatchV3StringHolder(new EuWestStringHolder());
            var tournamentCode = "10";
            var matchId = "11";
            var expected = $"{euRoot}/lol/match/v3/matches/{matchId}/by-tournament-code/{tournamentCode}{apiKeySuffix}";
        }
    }
}
