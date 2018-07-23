using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiotData.LoLCrawler
{
    public class ParticipantTimeline
    {
        public string lane { get; set; }
        public int participantId { get; set; }
        //some more properties are omitted but this should suffice for now
        //see api doc for missing properties
    }
}
