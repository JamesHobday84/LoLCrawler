using System;
using System.Collections.Generic;
using System.Text;

namespace LoLCrawler.RequestStringHolders
{
    public interface SharedStringHolder
    {
        string Root();
        string ApiKeySuffix();
    }
}
