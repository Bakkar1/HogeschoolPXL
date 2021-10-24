using Microsoft.EntityFrameworkCore.Migrations;

namespace HogeschoolPxl.Migrations
{
    public partial class relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LectorId",
                table: "VakLectoren",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "VakNaam",
                table: "Vakken",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VakLectoren_LectorId",
                table: "VakLectoren",
                column: "LectorId");

            migrationBuilder.CreateIndex(
                name: "IX_VakLectoren_VakId",
                table: "VakLectoren",
                column: "VakId");

            migrationBuilder.CreateIndex(
                name: "IX_Vakken_HandboekId",
                table: "Vakken",
                column: "HandboekId");

            migrationBuilder.CreateIndex(
                name: "IX_students_GebruikerId",
                table: "students",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectoren_GebruikerId",
                table: "Lectoren",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijvingen_AcademieJaarId",
                table: "Inschrijvingen",
                column: "AcademieJaarId");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijvingen_StudentId",
                table: "Inschrijvingen",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijvingen_VakLectorId",
                table: "Inschrijvingen",
                column: "VakLectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijvingen_AcademieJaaren_AcademieJaarId",
                table: "Inschrijvingen",
                column: "AcademieJaarId",
                principalTable: "AcademieJaaren",
                principalColumn: "AcademieJaarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijvingen_students_StudentId",
                table: "Inschrijvingen",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijvingen_VakLectoren_VakLectorId",
                table: "Inschrijvingen",
                column: "VakLectorId",
                principalTable: "VakLectoren",
                principalColumn: "VakLectorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectoren_Gebruikers_GebruikerId",
                table: "Lectoren",
                column: "GebruikerId",
                principalTable: "Gebruikers",
                principalColumn: "GebruikerId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_VakLectoren_Lectoren_LectorId",
                table: "VakLectoren",
                column: "LectorId",
                principalTable: "Lectoren",
                principalColumn: "LectorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VakLectoren_Vakken_VakId",
                table: "VakLectoren",
                column: "VakId",
                principalTable: "Vakken",
                principalColumn: "VakId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijvingen_AcademieJaaren_AcademieJaarId",
                table: "Inschrijvingen");

            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijvingen_students_StudentId",
                table: "Inschrijvingen");

            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijvingen_VakLectoren_VakLectorId",
                table: "Inschrijvingen");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectoren_Gebruikers_GebruikerId",
                table: "Lectoren");

            migrationBuilder.DropForeignKey(
                name: "FK_students_Gebruikers_GebruikerId",
                table: "students");

            migrationBuilder.DropForeignKey(
                name: "FK_Vakken_handboeken_HandboekId",
                table: "Vakken");

            migrationBuilder.DropForeignKey(
                name: "FK_VakLectoren_Lectoren_LectorId",
                table: "VakLectoren");

            migrationBuilder.DropForeignKey(
                name: "FK_VakLectoren_Vakken_VakId",
                table: "VakLectoren");

            migrationBuilder.DropIndex(
                name: "IX_VakLectoren_LectorId",
                table: "VakLectoren");

            migrationBuilder.DropIndex(
                name: "IX_VakLectoren_VakId",
                table: "VakLectoren");

            migrationBuilder.DropIndex(
                name: "IX_Vakken_HandboekId",
                table: "Vakken");

            migrationBuilder.DropIndex(
                name: "IX_students_GebruikerId",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_Lectoren_GebruikerId",
                table: "Lectoren");

            migrationBuilder.DropIndex(
                name: "IX_Inschrijvingen_AcademieJaarId",
                table: "Inschrijvingen");

            migrationBuilder.DropIndex(
                name: "IX_Inschrijvingen_StudentId",
                table: "Inschrijvingen");

            migrationBuilder.DropIndex(
                name: "IX_Inschrijvingen_VakLectorId",
                table: "Inschrijvingen");

            migrationBuilder.AlterColumn<int>(
                name: "LectorId",
                table: "VakLectoren",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VakNaam",
                table: "Vakken",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
