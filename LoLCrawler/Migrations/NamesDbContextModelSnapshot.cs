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
    partial class NamesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LoLCrawler.DatabaseEntity.LeagueDiv", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("rank");

                    b.Property<string>("summonerName");

                    b.Property<string>("tier");

                    b.HasKey("id");

                    b.ToTable("LeagueDivs");
                });

            modelBuilder.Entity("LoLCrawler.Name", b =>
                {
                    b.Property<int>("NameId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("summonerName");

                    b.HasKey("NameId");

                    b.ToTable("Names");
                });
#pragma warning restore 612, 618
        }
    }
}