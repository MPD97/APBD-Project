using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvertDatabaseCL.Migrations
{
    public partial class EmailAndLoginChangedToUniqeInClientsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Clients_Email",
                table: "Clients",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Login",
                table: "Clients",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clients_Email",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_Login",
                table: "Clients");
        }
    }
}
