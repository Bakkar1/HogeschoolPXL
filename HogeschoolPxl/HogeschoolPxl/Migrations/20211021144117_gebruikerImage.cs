using Microsoft.EntityFrameworkCore.Migrations;

namespace HogeschoolPxl.Migrations
{
    public partial class gebruikerImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Gebruikers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Gebruikers");
        }
    }
}
