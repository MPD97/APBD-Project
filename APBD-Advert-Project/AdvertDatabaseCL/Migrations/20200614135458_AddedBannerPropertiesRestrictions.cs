using Microsoft.EntityFrameworkCore.Migrations;

namespace Advert.Database.Migrations
{
    public partial class AddedBannerPropertiesRestrictions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Banners_Campaigns_CampaignIdCampaign",
                "Banners");

            migrationBuilder.DropIndex(
                "IX_Banners_CampaignIdCampaign",
                "Banners");

            migrationBuilder.DropColumn(
                "CampaignIdCampaign",
                "Banners");

            migrationBuilder.AlterColumn<decimal>(
                "Price",
                "Banners",
                "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                "Area",
                "Banners",
                "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                "IX_Banners_IdCampaign",
                "Banners",
                "IdCampaign");

            migrationBuilder.AddForeignKey(
                "FK_Banners_Campaigns_IdCampaign",
                "Banners",
                "IdCampaign",
                "Campaigns",
                principalColumn: "IdCampaign");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Banners_Campaigns_IdCampaign",
                "Banners");

            migrationBuilder.DropIndex(
                "IX_Banners_IdCampaign",
                "Banners");

            migrationBuilder.AlterColumn<decimal>(
                "Price",
                "Banners",
                "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AlterColumn<decimal>(
                "Area",
                "Banners",
                "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AddColumn<int>(
                "CampaignIdCampaign",
                "Banners",
                "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                "IX_Banners_CampaignIdCampaign",
                "Banners",
                "CampaignIdCampaign");

            migrationBuilder.AddForeignKey(
                "FK_Banners_Campaigns_CampaignIdCampaign",
                "Banners",
                "CampaignIdCampaign",
                "Campaigns",
                principalColumn: "IdCampaign",
                onDelete: ReferentialAction.Restrict);
        }
    }
}