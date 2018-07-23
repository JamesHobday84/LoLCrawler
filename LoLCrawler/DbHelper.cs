using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoLCrawler
{
    class DbHelper
    {
        public bool SubmitNameIfUnique(Name name)
        {
            if (!NameAlreadyExists(name))
            {
                submitName(name);
                return true;
            }

            return false;
        }
        public void submitName(Name name)
        {
            using (var context = new NamesDbContext())
            {
                context.Add(name);
            }
        }
        public bool NameAlreadyExists(Name name)
        {
            using (var context = new NamesDbContext())
            {
                Name queryResponse = context.Names.FirstOrDefault(a => a.NameId == name.NameId);
                return (queryResponse == null);
            }
        }
    }
}
