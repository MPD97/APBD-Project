using Microsoft.EntityFrameworkCore.Migrations;

namespace Advert.Database.Migrations
{
    public partial class AddedMoreBuildingSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                1,
                "StreetNumber",
                1);

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                2,
                new[] {"City", "Height", "Street", "StreetNumber"},
                new object[] {"Warszawa", 40.2m, "Afrodyty", 2});

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                3,
                new[] {"City", "Height", "Street", "StreetNumber"},
                new object[] {"Warszawa", 60.3m, "Afrodyty", 3});

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                4,
                new[] {"City", "Height", "Street", "StreetNumber"},
                new object[] {"Warszawa", 75m, "Afrodyty", 4});

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                5,
                new[] {"Height", "StreetNumber"},
                new object[] {90.5m, 5});

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                6,
                new[] {"City", "Height", "Street", "StreetNumber"},
                new object[] {"Warszawa", 120m, "Afrodyty", 6});

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                7,
                new[] {"City", "Height", "Street", "StreetNumber"},
                new object[] {"Warszawa", 23.5m, "Afrodyty", 7});

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                8,
                new[] {"City", "Height", "Street", "StreetNumber"},
                new object[] {"Warszawa", 30.8m, "Afrodyty", 8});

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                9,
                new[] {"City", "Height", "Street", "StreetNumber"},
                new object[] {"Warszawa", 88.6m, "Afrodyty", 9});

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                10,
                new[] {"Height", "Street", "StreetNumber"},
                new object[] {132.6m, "Afrodyty", 10});

            migrationBuilder.InsertData(
                "Buildings",
                new[] {"IdBuilding", "City", "Height", "Street", "StreetNumber"},
                new object[,]
                {
                    {39, "Poznan", 12.5m, "Kolejowa", 2},
                    {38, "Poznan", 11.5m, "Kolejowa", 1},
                    {37, "Poznan", 22.5m, "Sobótki", 5},
                    {36, "Poznan", 18.0m, "Sobótki", 4},
                    {35, "Poznan", 27.5m, "Sobótki", 3},
                    {34, "Poznan", 25.5m, "Sobótki", 2},
                    {33, "Poznan", 22.5m, "Sobótki", 1},
                    {32, "Gdańsk", 50.1m, "Portowa", 7},
                    {31, "Gdańsk", 54.5m, "Portowa", 6},
                    {40, "Poznan", 6.5m, "Kolejowa", 3},
                    {30, "Gdańsk", 52.2m, "Portowa", 5},
                    {28, "Gdańsk", 50.5m, "Portowa", 3},
                    {12, "Warszawa", 17.7m, "Potulicka", 2},
                    {13, "Warszawa", 44.5m, "Potulicka", 3},
                    {14, "Warszawa", 39.9m, "Potulicka", 4},
                    {15, "Warszawa", 89.0m, "Potulicka", 5},
                    {16, "Kraków", 133.3m, "Odległa", 1},
                    {17, "Kraków", 166.3m, "Odległa", 2},
                    {18, "Kraków", 45.0m, "Odległa", 3},
                    {29, "Gdańsk", 59.5m, "Portowa", 4},
                    {19, "Kraków", 44.2m, "Odległa", 4},
                    {21, "Kraków", 15.0m, "Uczniowska", 2},
                    {22, "Kraków", 15.0m, "Uczniowska", 3},
                    {23, "Kraków", 18.7m, "Popularna", 1},
                    {24, "Kraków", 18.7m, "Popularna", 2},
                    {25, "Kraków", 18.7m, "Popularna", 3},
                    {26, "Gdańsk", 50.5m, "Portowa", 1},
                    {27, "Gdańsk", 50.5m, "Portowa", 2},
                    {20, "Kraków", 12.0m, "Uczniowska", 1},
                    {11, "Warszawa", 35.7m, "Potulicka", 1}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                11);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                12);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                13);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                14);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                15);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                16);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                17);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                18);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                19);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                20);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                21);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                22);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                23);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                24);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                25);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                26);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                27);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                28);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                29);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                30);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                31);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                32);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                33);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                34);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                35);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                36);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                37);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                38);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                39);

            migrationBuilder.DeleteData(
                "Buildings",
                "IdBuilding",
                40);

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                1,
                "StreetNumber",
                11);

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                2,
                new[] {"City", "Height", "Street", "StreetNumber"},
                new object[] {"Kraków", 133.3m, "Odległa", 12});

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                3,
                new[] {"City", "Height", "Street", "StreetNumber"},
                new object[] {"Gdańsk", 12.5m, "Uczniowska", 44});

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                4,
                new[] {"City", "Height", "Street", "StreetNumber"},
                new object[] {"Kraków", 18.7m, "Popularna", 55});

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                5,
                new[] {"Height", "StreetNumber"},
                new object[] {19.2m, 262});

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                6,
                new[] {"City", "Height", "Street", "StreetNumber"},
                new object[] {"Kraków", 111.3m, "Popularna", 66});

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                7,
                new[] {"City", "Height", "Street", "StreetNumber"},
                new object[] {"Gdańsk", 50.5m, "Uczniowska", 8});

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                8,
                new[] {"City", "Height", "Street", "StreetNumber"},
                new object[] {"Poznan", 56.5m, "Sobótki", 9});

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                9,
                new[] {"City", "Height", "Street", "StreetNumber"},
                new object[] {"Poznan", 93.5m, "Sobótki", 4});

            migrationBuilder.UpdateData(
                "Buildings",
                "IdBuilding",
                10,
                new[] {"Height", "Street", "StreetNumber"},
                new object[] {40.4m, "Potulicka", 45});
        }
    }
}