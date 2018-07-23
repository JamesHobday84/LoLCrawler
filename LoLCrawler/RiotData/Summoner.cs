using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiotData.LoLCrawler
{
    public class Summoner
    {
        public string id { get; set; }
        public string accountId { get; set; }
        public string name { get; set; }
        public string profileIconId { get; set; }
        //milliseconds since epoch
        public long revisionDate { get; set; }
        public int summonerLevel { get; set; }
    }

}
