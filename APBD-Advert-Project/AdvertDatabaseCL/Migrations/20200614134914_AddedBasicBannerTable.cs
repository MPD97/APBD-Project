using Microsoft.EntityFrameworkCore.Migrations;

namespace Advert.Database.Migrations
{
    public partial class AddedBasicBannerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    IdAdvertisment = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    IdCampaign = table.Column<int>(nullable: false),
                    Area = table.Column<decimal>(nullable: false),
                    CampaignIdCampaign = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.IdAdvertisment);
                    table.ForeignKey(
                        name: "FK_Banners_Campaigns_CampaignIdCampaign",
                        column: x => x.CampaignIdCampaign,
                        principalTable: "Campaigns",
                        principalColumn: "IdCampaign",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Banners_CampaignIdCampaign",
                table: "Banners",
                column: "CampaignIdCampaign");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banners");
        }
    }
}
