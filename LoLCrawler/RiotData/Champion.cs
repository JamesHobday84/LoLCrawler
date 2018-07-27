using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.RiotData
{
    public class Champion
    {
        public bool rankedPlayEnabled { get; set; }
        public bool botEnabled { get; set; }
        public bool botMmEnabled { get; set; }
        public bool active { get; set; }
        public bool freeToPlay { get; set; }
        public long id { get; set; }
    }
}
