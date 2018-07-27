using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.RiotData
{
    class ChampionMastery
    {
        public bool chestGranted { get; set; }
        public int championLevel { get; set; }
        public int championPoints { get; set; }
        public long championId { get; set; }
        public long championPointsUntilNextLevel { get; set; }
        public int tokensEarnedInt { get; set; }
        public long championPointsSinceLastLevel { get; set; }
        public long lastPlayTime { get; set; }
    }
}
