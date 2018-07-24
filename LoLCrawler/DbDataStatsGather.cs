using LoLCrawler.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler
{
    class DbDataStatsGather
    {
        public void getLeagueDivStats()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            DbHelper dbHelper = new DbHelper();
            foreach(LeagueDiv leagueDiv in dbHelper.GetAllLeagueDivs())
            {
                if (dictionary.ContainsKey(leagueDiv.tier))
                {
                    int occurance = dictionary[leagueDiv.tier];
                    occurance++;
                    dictionary[leagueDiv.tier] = occurance;
                }
                else
                {
                    dictionary.Add(leagueDiv.tier, 1);
                }
            }

            foreach(KeyValuePair<string, int> pair in dictionary)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }

        }
    }
}
