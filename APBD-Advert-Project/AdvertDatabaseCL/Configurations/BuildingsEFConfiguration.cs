using Advert.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Advert.Database.Configurations
{
    public class BuildingsEFConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasKey(e => e.IdBuilding);

            builder.Property(e => e.Street)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.StreetNumber)
                .IsRequired();

            builder.Property(e => e.City)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Height)
                .HasColumnType("decimal(6,2)")
                .IsRequired();


            builder.HasData(new Building
                {
                    IdBuilding = 1,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 150.6M,
                    StreetNumber = 1
                }, new Building
                {
                    IdBuilding = 2,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 40.2M,
                    StreetNumber = 2
                }, new Building
                {
                    IdBuilding = 3,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 60.3M,
                    StreetNumber = 3
                }, new Building
                {
                    IdBuilding = 4,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 75M,
                    StreetNumber = 4
                }, new Building
                {
                    IdBuilding = 5,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 90.5M,
                    StreetNumber = 5
                }, new Building
                {
                    IdBuilding = 6,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 120M,
                    StreetNumber = 6
                }, new Building
                {
                    IdBuilding = 7,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 23.5M,
                    StreetNumber = 7
                }, new Building
                {
                    IdBuilding = 8,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 30.8M,
                    StreetNumber = 8
                }, new Building
                {
                    IdBuilding = 9,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 88.6M,
                    StreetNumber = 9
                }, new Building
                {
                    IdBuilding = 10,
                    Street = "Afrodyty",
                    City = "Warszawa",
                    Height = 132.6M,
                    StreetNumber = 10
                }, new Building
                {
                    IdBuilding = 11,
                    Street = "Potulicka",
                    City = "Warszawa",
                    Height = 35.7M,
                    StreetNumber = 1
                }, new Building
                {
                    IdBuilding = 12,
                    Street = "Potulicka",
                    City = "Warszawa",
                    Height = 17.7M,
                    StreetNumber = 2
                }, new Building
                {
                    IdBuilding = 13,
                    Street = "Potulicka",
                    City = "Warszawa",
                    Height = 44.5M,
                    StreetNumber = 3
                }, new Building
                {
                    IdBuilding = 14,
                    Street = "Potulicka",
                    City = "Warszawa",
                    Height = 39.9M,
                    StreetNumber = 4
                }, new Building
                {
                    IdBuilding = 15,
                    Street = "Potulicka",
                    City = "Warszawa",
                    Height = 89.0M,
                    StreetNumber = 5
                },
                new Building
                {
                    IdBuilding = 16,
                    Street = "Odległa",
                    City = "Kraków",
                    Height = 133.3M,
                    StreetNumber = 1
                },
                new Building
                {
                    IdBuilding = 17,
                    Street = "Odległa",
                    City = "Kraków",
                    Height = 166.3M,
                    StreetNumber = 2
                },
                new Building
                {
                    IdBuilding = 18,
                    Street = "Odległa",
                    City = "Kraków",
                    Height = 45.0M,
                    StreetNumber = 3
                },
                new Building
                {
                    IdBuilding = 19,
                    Street = "Odległa",
                    City = "Kraków",
                    Height = 44.2M,
                    StreetNumber = 4
                }, new Building
                {
                    IdBuilding = 20,
                    Street = "Uczniowska",
                    City = "Kraków",
                    Height = 12.0M,
                    StreetNumber = 1
                }, new Building
                {
                    IdBuilding = 21,
                    Street = "Uczniowska",
                    City = "Kraków",
                    Height = 15.0M,
                    StreetNumber = 2
                }, new Building
                {
                    IdBuilding = 22,
                    Street = "Uczniowska",
                    City = "Kraków",
                    Height = 15.0M,
                    StreetNumber = 3
                }, new Building
                {
                    IdBuilding = 23,
                    Street = "Popularna",
                    City = "Kraków",
                    Height = 18.7M,
                    StreetNumber = 1
                }, new Building
                {
                    IdBuilding = 24,
                    Street = "Popularna",
                    City = "Kraków",
                    Height = 18.7M,
                    StreetNumber = 2
                }, new Building
                {
                    IdBuilding = 25,
                    Street = "Popularna",
                    City = "Kraków",
                    Height = 18.7M,
                    StreetNumber = 3
                }, new Building
                {
                    IdBuilding = 26,
                    Street = "Portowa",
                    City = "Gdańsk",
                    Height = 50.5M,
                    StreetNumber = 1
                }, new Building
                {
                    IdBuilding = 27,
                    Street = "Portowa",
                    City = "Gdańsk",
                    Height = 50.5M,
                    StreetNumber = 2
                }, new Building
                {
                    IdBuilding = 28,
                    Street = "Portowa",
                    City = "Gdańsk",
                    Height = 50.5M,
                    StreetNumber = 3
                }, new Building
                {
                    IdBuilding = 29,
                    Street = "Portowa",
                    City = "Gdańsk",
                    Height = 59.5M,
                    StreetNumber = 4
                }, new Building
                {
                    IdBuilding = 30,
                    Street = "Portowa",
                    City = "Gdańsk",
                    Height = 52.2M,
                    StreetNumber = 5
                }, new Building
                {
                    IdBuilding = 31,
                    Street = "Portowa",
                    City = "Gdańsk",
                    Height = 54.5M,
                    StreetNumber = 6
                }, new Building
                {
                    IdBuilding = 32,
                    Street = "Portowa",
                    City = "Gdańsk",
                    Height = 50.1M,
                    StreetNumber = 7
                }, new Building
                {
                    IdBuilding = 33,
                    Street = "Sobótki",
                    City = "Poznan",
                    Height = 22.5M,
                    StreetNumber = 1
                }, new Building
                {
                    IdBuilding = 34,
                    Street = "Sobótki",
                    City = "Poznan",
                    Height = 25.5M,
                    StreetNumber = 2
                }, new Building
                {
                    IdBuilding = 35,
                    Street = "Sobótki",
                    City = "Poznan",
                    Height = 27.5M,
                    StreetNumber = 3
                }, new Building
                {
                    IdBuilding = 36,
                    Street = "Sobótki",
                    City = "Poznan",
                    Height = 18.0M,
                    StreetNumber = 4
                }, new Building
                {
                    IdBuilding = 37,
                    Street = "Sobótki",
                    City = "Poznan",
                    Height = 22.5M,
                    StreetNumber = 5
                }, new Building
                {
                    IdBuilding = 38,
                    Street = "Kolejowa",
                    City = "Poznan",
                    Height = 11.5M,
                    StreetNumber = 1
                }, new Building
                {
                    IdBuilding = 39,
                    Street = "Kolejowa",
                    City = "Poznan",
                    Height = 12.5M,
                    StreetNumber = 2
                }, new Building
                {
                    IdBuilding = 40,
                    Street = "Kolejowa",
                    City = "Poznan",
                    Height = 6.5M,
                    StreetNumber = 3
                });
        }
    }
}