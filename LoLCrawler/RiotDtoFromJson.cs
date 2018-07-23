using RiotData.LoLCrawler;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LoLCrawler
{
    static class RiotDtoFromJson
    {
        public static Summoner getSummoner(string json)
        {
            return JsonConvert.DeserializeObject<Summoner>(json);
        }
        public static MatchList GetMatchList(string json)
        {
            return JsonConvert.DeserializeObject<MatchList>(json);
        }
    }
}
