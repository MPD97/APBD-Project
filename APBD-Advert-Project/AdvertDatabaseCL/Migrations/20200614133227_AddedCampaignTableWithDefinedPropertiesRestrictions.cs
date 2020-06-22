using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Advert.Database.Migrations
{
    public partial class AddedCampaignTableWithDefinedPropertiesRestrictions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Campaigns",
                table => new
                {
                    IdCampaign = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    PricePerSquareMeter = table.Column<decimal>("decimal(6,2)", nullable: false),
                    FromIdBuilding = table.Column<int>(nullable: false),
                    ToIdBuilding = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.IdCampaign);
                    table.ForeignKey(
                        "FK_Campaigns_Buildings_FromIdBuilding",
                        x => x.FromIdBuilding,
                        "Buildings",
                        "IdBuilding");
                    table.ForeignKey(
                        "FK_Campaigns_Clients_IdClient",
                        x => x.IdClient,
                        "Clients",
                        "IdClient");
                    table.ForeignKey(
                        "FK_Campaigns_Buildings_ToIdBuilding",
                        x => x.ToIdBuilding,
                        "Buildings",
                        "IdBuilding");
                });

            migrationBuilder.CreateIndex(
                "IX_Campaigns_FromIdBuilding",
                "Campaigns",
                "FromIdBuilding");

            migrationBuilder.CreateIndex(
                "IX_Campaigns_IdClient",
                "Campaigns",
                "IdClient");

            migrationBuilder.CreateIndex(
                "IX_Campaigns_ToIdBuilding",
                "Campaigns",
                "ToIdBuilding");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Campaigns");
        }
    }
}