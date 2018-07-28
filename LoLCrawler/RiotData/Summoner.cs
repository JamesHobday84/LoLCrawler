using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiotData.LoLCrawler
{
    public class Summoner
    {
        //this is the value needed to access league position data.
        public string id { get; set; }
        //this is the id needed to access matchHistory data.
        public string accountId { get; set; }
        public string name { get; set; }
        public string profileIconId { get; set; }
        //milliseconds since epoch
        public long revisionDate { get; set; }
        public int summonerLevel { get; set; }
    }
}
