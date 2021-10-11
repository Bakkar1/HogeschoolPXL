using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HogeschoolPxl.Migrations
{
    public partial class InitialSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademieJaaren",
                columns: table => new
                {
                    AcademieJaarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademieJaaren", x => x.AcademieJaarId);
                });

            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    GebruikerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: false),
                    VoorNaam = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.GebruikerId);
                });

            migrationBuilder.CreateTable(
                name: "handboeken",
                columns: table => new
                {
                    HandboekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    KostPrijs = table.Column<double>(nullable: false),
                    UitGifteDatum = table.Column<DateTime>(nullable: false),
                    Afbeelding = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_handboeken", x => x.HandboekId);
                });

            migrationBuilder.CreateTable(
                name: "Inschrijvingen",
                columns: table => new
                {
                    InschrijvingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    VakLectorId = table.Column<int>(nullable: false),
                    AcademieJaarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inschrijvingen", x => x.InschrijvingId);
                });

            migrationBuilder.CreateTable(
                name: "Lectoren",
                columns: table => new
                {
                    LectorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectoren", x => x.LectorId);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Vakken",
                columns: table => new
                {
                    VakId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VakNaam = table.Column<string>(nullable: true),
                    Studiepunten = table.Column<int>(nullable: false),
                    HandboekId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vakken", x => x.VakId);
                });

            migrationBuilder.CreateTable(
                name: "VakLectoren",
                columns: table => new
                {
                    VakLectorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LectorId = table.Column<int>(nullable: false),
                    GebruikerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VakLectoren", x => x.VakLectorId);
                });

            migrationBuilder.InsertData(
                table: "AcademieJaaren",
                columns: new[] { "AcademieJaarId", "StartDatum" },
                values: new object[] { 1, new DateTime(2021, 10, 9, 18, 34, 9, 739, DateTimeKind.Local).AddTicks(8769) });

            migrationBuilder.InsertData(
                table: "Gebruikers",
                columns: new[] { "GebruikerId", "Email", "Naam", "VoorNaam" },
                values: new object[,]
                {
                    { 1, "mbark.bakkar@pxl.be", "Bakkar", "Mbark" },
                    { 2, "Kristof.Palmaers@pxl.be", "Palmaers", "Kristof" }
                });

            migrationBuilder.InsertData(
                table: "Inschrijvingen",
                columns: new[] { "InschrijvingId", "AcademieJaarId", "StudentId", "VakLectorId" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Lectoren",
                columns: new[] { "LectorId", "GebruikerId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "VakLectoren",
                columns: new[] { "VakLectorId", "GebruikerId", "LectorId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Vakken",
                columns: new[] { "VakId", "HandboekId", "Studiepunten", "VakNaam" },
                values: new object[] { 1, 1, 5, "C# Web" });

            migrationBuilder.InsertData(
                table: "handboeken",
                columns: new[] { "HandboekId", "Afbeelding", "KostPrijs", "Title", "UitGifteDatum" },
                values: new object[] { 1, null, 30.0, "C# Web 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "StudentId", "GebruikerId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademieJaaren");

            migrationBuilder.DropTable(
                name: "Gebruikers");

            migrationBuilder.DropTable(
                name: "handboeken");

            migrationBuilder.DropTable(
                name: "Inschrijvingen");

            migrationBuilder.DropTable(
                name: "Lectoren");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "Vakken");

            migrationBuilder.DropTable(
                name: "VakLectoren");
        }
    }
}
