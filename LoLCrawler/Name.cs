using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler
{
    class Name
    {
        public Name(){}
        public Name(string name)
        {
            this.summonerName = name;
        }
        public int NameId { get; set; }
        public string summonerName { get; set; }

    }
}
