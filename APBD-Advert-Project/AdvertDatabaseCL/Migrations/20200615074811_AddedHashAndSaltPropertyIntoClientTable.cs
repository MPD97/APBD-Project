using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvertDatabaseCL.Migrations
{
    public partial class AddedHashAndSaltPropertyIntoClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hash",
                table: "Clients",
                maxLength: 44,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Clients",
                maxLength: 24,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hash",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Clients");
        }
    }
}
