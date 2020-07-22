using Microsoft.EntityFrameworkCore.Migrations;

namespace Advert.Database.Migrations
{
    public partial class EmailAndLoginChangedToUniqeInClientsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                "IX_Clients_Email",
                "Clients",
                "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Clients_Login",
                "Clients",
                "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                "IX_Clients_Email",
                "Clients");

            migrationBuilder.DropIndex(
                "IX_Clients_Login",
                "Clients");
        }
    }
}