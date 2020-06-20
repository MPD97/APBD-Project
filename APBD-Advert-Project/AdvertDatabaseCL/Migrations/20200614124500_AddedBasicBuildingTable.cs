using Microsoft.EntityFrameworkCore.Migrations;

namespace Advert.Database.Migrations
{
    public partial class AddedBasicBuildingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Buildings",
                table => new
                {
                    IdBuilding = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Height = table.Column<decimal>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Buildings", x => x.IdBuilding); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Buildings");
        }
    }
}