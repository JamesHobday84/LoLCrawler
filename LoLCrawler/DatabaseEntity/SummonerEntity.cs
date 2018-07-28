using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.DatabaseEntity
{
    public class SummonerEntity
    {
        public int SummonerEntityId { get; set; }
        
        //this is the value needed to access league position data.
        public string SummonerId { get; set; }
        //this is the id needed to access matchHistory data.
        public string AccountId { get; set; }
        public string Name { get; set; }
        public string ProfileIconId { get; set; }
        //milliseconds since epoch
        public long RevisionDate { get; set; }
        public int SummonerLevel { get; set; }
    }
}
