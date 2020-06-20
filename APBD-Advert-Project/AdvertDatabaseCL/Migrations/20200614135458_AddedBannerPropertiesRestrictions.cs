using Microsoft.EntityFrameworkCore.Migrations;

namespace Advert.Database.Migrations
{
    public partial class AddedBannerPropertiesRestrictions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_Campaigns_CampaignIdCampaign",
                table: "Banners");

            migrationBuilder.DropIndex(
                name: "IX_Banners_CampaignIdCampaign",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "CampaignIdCampaign",
                table: "Banners");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Banners",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Area",
                table: "Banners",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_Banners_IdCampaign",
                table: "Banners",
                column: "IdCampaign");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_Campaigns_IdCampaign",
                table: "Banners",
                column: "IdCampaign",
                principalTable: "Campaigns",
                principalColumn: "IdCampaign");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_Campaigns_IdCampaign",
                table: "Banners");

            migrationBuilder.DropIndex(
                name: "IX_Banners_IdCampaign",
                table: "Banners");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Banners",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Area",
                table: "Banners",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AddColumn<int>(
                name: "CampaignIdCampaign",
                table: "Banners",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Banners_CampaignIdCampaign",
                table: "Banners",
                column: "CampaignIdCampaign");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_Campaigns_CampaignIdCampaign",
                table: "Banners",
                column: "CampaignIdCampaign",
                principalTable: "Campaigns",
                principalColumn: "IdCampaign",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
