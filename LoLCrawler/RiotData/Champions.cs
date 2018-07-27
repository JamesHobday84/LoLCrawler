using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.RiotData
{
    /*
     * This class is never specified as a DTO in the riot api documentation
     * but is required as instead of supplying a list of champion objects as 
     * the docs say it instead suppies a Champions object within which there
     * is a list of of champion items. This class is tehrefor enecessary to
     * use JsonConvert to go directly from Json to a class.
     */

    public class Champions
    {
        public IEnumerable<Champion> champions { get; set; }
    }
}
