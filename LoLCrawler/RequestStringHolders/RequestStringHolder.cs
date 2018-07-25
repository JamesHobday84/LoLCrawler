using LoLCrawler.RequestStringHolders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler
{
    public class RequestStringHolder
    {

        public RequestStringHolder()
        {
            EuWestStringHolder = new EuWestStringHolder();
            ChampionMastery = new ChampionMasteryV3StringHolder(EuWestStringHolder);
            //add champion api object here once added to project.
            League = new LeagueV3StringHolder(EuWestStringHolder);
            LolStatus = new LolStatusV3StringHolder(EuWestStringHolder);
            Match = new MatchV3(EuWestStringHolder);
            Spectator = new SpectatorV3StringHolder(EuWestStringHolder);
            Summoner = new SummonerV3StringHolder(EuWestStringHolder);            
        }


        public EuWestStringHolder EuWestStringHolder;
        public ChampionMasteryV3StringHolder ChampionMastery;
        //forgot to add championApi object, do this and put it here.
        public LeagueV3StringHolder League;
        public LolStatusV3StringHolder LolStatus;
        public MatchV3 Match;
        public SpectatorV3StringHolder Spectator;
        public SummonerV3StringHolder Summoner;
    }
}
