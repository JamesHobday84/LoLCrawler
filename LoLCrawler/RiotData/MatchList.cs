using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiotData.LoLCrawler
{
    public class MatchList
    {
        public List<Match> matches { get; set; }
        public int totalGames { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
    }
}
