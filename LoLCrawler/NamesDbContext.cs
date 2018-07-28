using System;
using System.Collections.Generic;
using System.Text;
using LoLCrawler.DatabaseEntity;
using Microsoft.EntityFrameworkCore;
using RiotData.LoLCrawler;

namespace LoLCrawler
{
    class NamesDbContext : DbContext
    {
        public DbSet<Summoner> Summoners { get; set; }

        public DbSet<MatchDetailed> MatchesDetailed { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=master;
                            Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                                ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
