using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LoLCrawler.Migrations
{
    public partial class LeagesNowWithCapitalLetter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_leagues",
                table: "leagues");

            migrationBuilder.RenameTable(
                name: "leagues",
                newName: "Leagues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leagues",
                table: "Leagues",
                column: "LeagueEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Leagues",
                table: "Leagues");

            migrationBuilder.RenameTable(
                name: "Leagues",
                newName: "leagues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_leagues",
                table: "leagues",
                column: "LeagueEntityId");
        }
    }
}
