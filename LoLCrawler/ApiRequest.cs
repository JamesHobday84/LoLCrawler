using LoLCrawler.ApiRequests;
using LoLCrawler.RiotData;
using Newtonsoft.Json;
using RiotData.LoLCrawler;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler
{
    class ApiRequest
    {
        public ApiRequest(RequestStringHolder rsh)
        {
            requestStringHolder = rsh;
            ChampionMastery = new ChampionMasteryV3Request(rsh);
            Champion = new ChampionV3Request(rsh);
            League = new LeagueV3Request(rsh);
            Match = new MatchV3Request(rsh);
            Summoner = new SummonerV3Request(rsh);
        }

        private RequestStringHolder requestStringHolder;
        public ChampionMasteryV3Request ChampionMastery;
        public ChampionV3Request Champion;
        public LeagueV3Request League;
        public MatchV3Request Match;
        public SummonerV3Request Summoner;        
    }
}
