using Microsoft.EntityFrameworkCore.Migrations;

namespace HogeschoolPxl.Migrations
{
    public partial class initialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Gebruikers",
                columns: new[] { "GebruikerId", "Email", "Naam", "VoorNaam" },
                values: new object[] { 1, "mbark.bakkar@pxl.be", "Bakkar", "Mbark" });

            migrationBuilder.InsertData(
                table: "Gebruikers",
                columns: new[] { "GebruikerId", "Email", "Naam", "VoorNaam" },
                values: new object[] { 2, "Kristof.Palmaers@pxl.be", "Palmaers", "Kristof" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gebruikers",
                keyColumn: "GebruikerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gebruikers",
                keyColumn: "GebruikerId",
                keyValue: 2);
        }
    }
}
