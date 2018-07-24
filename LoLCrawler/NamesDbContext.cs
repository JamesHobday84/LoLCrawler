using System;
using System.Collections.Generic;
using System.Text;
using LoLCrawler.DatabaseEntity;
using Microsoft.EntityFrameworkCore;

namespace LoLCrawler
{
    class NamesDbContext : DbContext
    {
        public DbSet<Name> Names { get; set; }

        public DbSet<LeagueDiv> LeagueDivs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=master;
                            Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                                ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
