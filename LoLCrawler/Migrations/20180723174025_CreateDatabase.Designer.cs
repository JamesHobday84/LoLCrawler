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
    [Migration("20180723174025_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
