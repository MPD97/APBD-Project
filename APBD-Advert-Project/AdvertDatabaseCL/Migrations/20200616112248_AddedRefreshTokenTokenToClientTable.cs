using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvertDatabaseCL.Migrations
{
    public partial class AddedRefreshTokenTokenToClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Clients",
                maxLength: 36,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Clients");
        }
    }
}
