using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvertDatabaseCL.Migrations
{
    public partial class BuildingsAddedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "IdBuilding", "City", "Height", "Street", "StreetNumber" },
                values: new object[,]
                {
                    { 1, "Warszawa", 150.6m, "Afrodyty", 11 },
                    { 2, "Kraków", 133.3m, "Odległa", 12 },
                    { 3, "Gdańsk", 12.5m, "Uczniowska", 44 },
                    { 4, "Kraków", 18.7m, "Popularna", 55 },
                    { 5, "Warszawa", 19.2m, "Afrodyty", 262 },
                    { 6, "Kraków", 111.3m, "Popularna", 66 },
                    { 7, "Gdańsk", 50.5m, "Uczniowska", 8 },
                    { 8, "Poznan", 56.5m, "Sobótki", 9 },
                    { 9, "Poznan", 93.5m, "Sobótki", 4 },
                    { 10, "Warszawa", 40.4m, "Potulicka", 45 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "IdBuilding",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "IdBuilding",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "IdBuilding",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "IdBuilding",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "IdBuilding",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "IdBuilding",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "IdBuilding",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "IdBuilding",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "IdBuilding",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "IdBuilding",
                keyValue: 10);
        }
    }
}
