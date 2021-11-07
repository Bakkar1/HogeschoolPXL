using Microsoft.EntityFrameworkCore.Migrations;

namespace HogeschoolPxl.Migrations
{
    public partial class tablesNameHoofdLetters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijvingen_students_StudentId",
                table: "Inschrijvingen");

            migrationBuilder.DropForeignKey(
                name: "FK_students_Gebruikers_GebruikerId",
                table: "students");

            migrationBuilder.DropForeignKey(
                name: "FK_Vakken_handboeken_HandboekId",
                table: "Vakken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_students",
                table: "students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_handboeken",
                table: "handboeken");

            migrationBuilder.RenameTable(
                name: "students",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "handboeken",
                newName: "Handboeken");

            migrationBuilder.RenameIndex(
                name: "IX_students_GebruikerId",
                table: "Students",
                newName: "IX_Students_GebruikerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Handboeken",
                table: "Handboeken",
                column: "HandboekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijvingen_Students_StudentId",
                table: "Inschrijvingen",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Gebruikers_GebruikerId",
                table: "Students",
                column: "GebruikerId",
                principalTable: "Gebruikers",
                principalColumn: "GebruikerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vakken_Handboeken_HandboekId",
                table: "Vakken",
                column: "HandboekId",
                principalTable: "Handboeken",
                principalColumn: "HandboekId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijvingen_Students_StudentId",
                table: "Inschrijvingen");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Gebruikers_GebruikerId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Vakken_Handboeken_HandboekId",
                table: "Vakken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Handboeken",
                table: "Handboeken");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "students");

            migrationBuilder.RenameTable(
                name: "Handboeken",
                newName: "handboeken");

            migrationBuilder.RenameIndex(
                name: "IX_Students_GebruikerId",
                table: "students",
                newName: "IX_students_GebruikerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_students",
                table: "students",
                column: "StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_handboeken",
                table: "handboeken",
                column: "HandboekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijvingen_students_StudentId",
                table: "Inschrijvingen",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_students_Gebruikers_GebruikerId",
                table: "students",
                column: "GebruikerId",
                principalTable: "Gebruikers",
                principalColumn: "GebruikerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vakken_handboeken_HandboekId",
                table: "Vakken",
                column: "HandboekId",
                principalTable: "handboeken",
                principalColumn: "HandboekId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
