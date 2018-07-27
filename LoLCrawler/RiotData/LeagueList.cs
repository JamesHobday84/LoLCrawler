using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.RiotData
{
    public class LeagueList
    {
        public string leagueId { get; set; }
        public string tier { get; set; }
        public IEnumerable<LeaguePosition> entries { get; set; }
        public string queue { get; set; }
        public string name { get; set; }
    }
}
