using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.DatabaseEntity
{
    class LeagueEntity
    {
        public int LeagueEntityId{ get; set; }

        public string Tier { get; set; }
        public string Queue { get; set; }
        public string LeagueId { get; set; }
        public string Name { get; set; }
    }
}
