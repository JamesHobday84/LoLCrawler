using RiotData.LoLCrawler;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

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
    }
}
