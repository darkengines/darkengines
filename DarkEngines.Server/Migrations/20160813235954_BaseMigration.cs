using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkEngines.Server.Migrations
{
    public partial class BaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Code = table.Column<string>(nullable: true),
                    DecimalDigits = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NamePlural = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    SymbolNative = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
