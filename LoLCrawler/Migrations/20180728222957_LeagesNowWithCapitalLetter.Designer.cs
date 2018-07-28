﻿// <auto-generated />
using LoLCrawler;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace LoLCrawler.Migrations
{
    [DbContext(typeof(NamesDbContext))]
    [Migration("20180728222957_LeagesNowWithCapitalLetter")]
    partial class LeagesNowWithCapitalLetter
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LoLCrawler.DatabaseEntity.LeagueEntity", b =>
                {
                    b.Property<int>("LeagueEntityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LeagueId");

                    b.Property<string>("Name");

                    b.Property<string>("Queue");

                    b.Property<string>("Tier");

                    b.HasKey("LeagueEntityId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("LoLCrawler.DatabaseEntity.SummonerEntity", b =>
                {
                    b.Property<int>("SummonerEntityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountId");

                    b.Property<string>("Name");

                    b.Property<string>("ProfileIconId");

                    b.Property<long>("RevisionDate");

                    b.Property<string>("SummonerId");

                    b.Property<int>("SummonerLevel");

                    b.HasKey("SummonerEntityId");

                    b.ToTable("Summoners");
                });
#pragma warning restore 612, 618
        }
    }
}
