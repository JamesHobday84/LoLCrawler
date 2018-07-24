using RiotData.LoLCrawler;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using LoLCrawler.RiotData;

namespace LoLCrawler
{
    static class RiotDtoFromJson
    {
        public static Summoner GetSummoner(string json)
        {
            return JsonConvert.DeserializeObject<Summoner>(json);
        }
        public static MatchList GetMatchList(string json)
        {
            return JsonConvert.DeserializeObject<MatchList>(json);
        }
        public static MatchDetailed GetMatchDetailed(string json)
        {
            return JsonConvert.DeserializeObject<MatchDetailed>(json);
        }
        public static IEnumerable<LeaguePosition> GetLeaguePositionList(string json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<LeaguePosition>>(json);
        }
    }
}
