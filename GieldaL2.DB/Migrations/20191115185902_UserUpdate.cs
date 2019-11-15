using Microsoft.EntityFrameworkCore.Migrations;

namespace GieldaL2.DB.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Users");
        }
    }
}
