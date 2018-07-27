using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.RiotData
{
    public class LeaguePosition
    {
        public string rank { get; set; }
        public string queueType { get; set; }
        public bool hotStreak { get; set; }
        public MiniSeries miniSeries { get; set; }
        public int wins { get; set; }
        public bool veteran { get; set; }
        public int losses { get; set; }
        public bool freshBlood { get; set; }
        public string leagueId { get; set; }
        public string playerOrTeamName { get; set; }
        public bool inactive { get; set; }
        public string playerOrTeamId { get; set; }
        public string leagueName { get; set; }
        public string tier { get; set; }
        public int leaguePoints { get; set; }
    }
}
