using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.DatabaseEntity
{
    class LeagueDiv
    {
        public LeagueDiv() { }
        public LeagueDiv(string name)
        {
            summonerName = name;
            tier = "UNRANKED";
            rank = "UNRANKED";
        }

        public int id { get; set; }
        public string summonerName { get; set; }
        public string tier { get; set; }
        public string rank { get; set; }
    }
}
