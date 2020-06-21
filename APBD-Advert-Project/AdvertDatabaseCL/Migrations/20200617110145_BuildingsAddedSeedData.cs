using Microsoft.EntityFrameworkCore.Migrations;

namespace Advert.Database.Migrations
{
    public partial class BuildingsAddedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "Buildings",
                new[] {"IdBuilding", "City", "Height", "Street", "StreetNumber"},
                new object[,]
                {
                    {1, "Warszawa", 150.6m, "Afrodyty", 11},
                    {2, "Kraków", 133.3m, "Odległa", 12},
                    {3, "Gdańsk", 12.5m, "Uczniowska", 44},
                    {4, "Kraków", 18.7m, "Popularna", 55},
                    {5, "Warszawa", 19.2m, "Afrodyty", 262},
                    {6, "Kraków", 111.3m, "Popularna", 66},
                    {7, "Gdańsk", 50.5m, "Uczniowska", 8},
                    {8, "Poznan", 56.5m, "Sobótki", 9},
                    {9, "Poznan", 93.5m, "Sobótki", 4},
                    {10, "Warszawa", 40.4m, "Potulicka", 45}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                1);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                2);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                3);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                4);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                5);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                6);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                7);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                8);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                9);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                10);
        }
    }
}