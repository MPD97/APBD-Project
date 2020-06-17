using AdvertDatabaseCL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertDatabaseCL.Configurations
{
    public class BuildingsEFConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasKey(e => e.IdBuilding);

            builder.Property(e => e.Street)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(e => e.StreetNumber)
               .IsRequired(true);

            builder.Property(e => e.City)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(e => e.Height)
                .HasColumnType("decimal(6,2)")
                .IsRequired(true);


            builder.HasData(new Building
            {
                IdBuilding = 1,
                Street = "Afrodyty",
                City = "Warszawa",
                Height = 150.6M,
                StreetNumber = 11
            },new Building
            {
                IdBuilding = 2,
                Street = "Odległa",
                City = "Kraków",
                Height = 133.3M,
                StreetNumber = 12
            },new Building
            {
                IdBuilding = 3,
                Street = "Uczniowska",
                City = "Gdańsk",
                Height = 12.5M,
                StreetNumber = 44
            },new Building
            {
                IdBuilding = 4,
                Street = "Popularna",
                City = "Kraków",
                Height = 18.7M,
                StreetNumber = 55
            },new Building
            {
                IdBuilding = 5,
                Street = "Afrodyty",
                City = "Warszawa",
                Height = 19.2M,
                StreetNumber = 262
            },new Building
            {
                IdBuilding = 6,
                Street = "Popularna",
                City = "Kraków",
                Height = 111.3M,
                StreetNumber = 66
            }, new Building
            {
                IdBuilding = 7,
                Street = "Uczniowska",
                City = "Gdańsk",
                Height = 50.5M,
                StreetNumber = 8
            }, new Building
            {
                IdBuilding = 8,
                Street = "Sobótki",
                City = "Poznan",
                Height = 56.5M,
                StreetNumber = 9
            }, new Building
            {
                IdBuilding = 9,
                Street = "Sobótki",
                City = "Poznan",
                Height = 93.5M,
                StreetNumber = 4
            }, new Building
            {
                IdBuilding = 10,
                Street = "Potulicka",
                City = "Warszawa",
                Height = 40.4M,
                StreetNumber = 45
            });
        }
    }
}
