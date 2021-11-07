using Microsoft.EntityFrameworkCore.Migrations;

namespace HogeschoolPxl.Migrations
{
    public partial class updateAcademieJarenName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijvingen_AcademieJaaren_AcademieJaarId",
                table: "Inschrijvingen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AcademieJaaren",
                table: "AcademieJaaren");

            migrationBuilder.RenameTable(
                name: "AcademieJaaren",
                newName: "AcademieJaren");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AcademieJaren",
                table: "AcademieJaren",
                column: "AcademieJaarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijvingen_AcademieJaren_AcademieJaarId",
                table: "Inschrijvingen",
                column: "AcademieJaarId",
                principalTable: "AcademieJaren",
                principalColumn: "AcademieJaarId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijvingen_AcademieJaren_AcademieJaarId",
                table: "Inschrijvingen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AcademieJaren",
                table: "AcademieJaren");

            migrationBuilder.RenameTable(
                name: "AcademieJaren",
                newName: "AcademieJaaren");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AcademieJaaren",
                table: "AcademieJaaren",
                column: "AcademieJaarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijvingen_AcademieJaaren_AcademieJaarId",
                table: "Inschrijvingen",
                column: "AcademieJaarId",
                principalTable: "AcademieJaaren",
                principalColumn: "AcademieJaarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
