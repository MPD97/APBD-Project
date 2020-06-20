using Microsoft.EntityFrameworkCore.Migrations;

namespace Advert.Database.Migrations
{
    public partial class AddedHashAndSaltPropertyIntoClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "Hash",
                "Clients",
                maxLength: 44,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                "Salt",
                "Clients",
                maxLength: 24,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Hash",
                "Clients");

            migrationBuilder.DropColumn(
                "Salt",
                "Clients");
        }
    }
}