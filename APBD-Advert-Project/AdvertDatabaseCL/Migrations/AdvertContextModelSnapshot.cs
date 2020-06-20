﻿// <auto-generated />

using System;
using Advert.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Advert.Database.Migrations
{
    [DbContext(typeof(AdvertContext))]
    internal class AdvertContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdvertDatabaseCL.Configurations.Banner", b =>
            {
                b.Property<int>("IdAdvertisment")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<decimal>("Area")
                    .HasColumnType("decimal(6,2)");

                b.Property<int>("IdCampaign")
                    .HasColumnType("int");

                b.Property<int>("Name")
                    .HasColumnType("int");

                b.Property<decimal>("Price")
                    .HasColumnType("decimal(6,2)");

                b.HasKey("IdAdvertisment");

                b.HasIndex("IdCampaign");

                b.ToTable("Banners");
            });

            modelBuilder.Entity("AdvertDatabaseCL.Entities.Building", b =>
            {
                b.Property<int>("IdBuilding")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("City")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<decimal>("Height")
                    .HasColumnType("decimal(6,2)");

                b.Property<string>("Street")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<int>("StreetNumber")
                    .HasColumnType("int");

                b.HasKey("IdBuilding");

                b.ToTable("Buildings");

                b.HasData(
                    new
                    {
                        IdBuilding = 1,
                        City = "Warszawa",
                        Height = 150.6m,
                        Street = "Afrodyty",
                        StreetNumber = 11
                    },
                    new
                    {
                        IdBuilding = 2,
                        City = "Kraków",
                        Height = 133.3m,
                        Street = "Odległa",
                        StreetNumber = 12
                    },
                    new
                    {
                        IdBuilding = 3,
                        City = "Gdańsk",
                        Height = 12.5m,
                        Street = "Uczniowska",
                        StreetNumber = 44
                    },
                    new
                    {
                        IdBuilding = 4,
                        City = "Kraków",
                        Height = 18.7m,
                        Street = "Popularna",
                        StreetNumber = 55
                    },
                    new
                    {
                        IdBuilding = 5,
                        City = "Warszawa",
                        Height = 19.2m,
                        Street = "Afrodyty",
                        StreetNumber = 262
                    },
                    new
                    {
                        IdBuilding = 6,
                        City = "Kraków",
                        Height = 111.3m,
                        Street = "Popularna",
                        StreetNumber = 66
                    },
                    new
                    {
                        IdBuilding = 7,
                        City = "Gdańsk",
                        Height = 50.5m,
                        Street = "Uczniowska",
                        StreetNumber = 8
                    },
                    new
                    {
                        IdBuilding = 8,
                        City = "Poznan",
                        Height = 56.5m,
                        Street = "Sobótki",
                        StreetNumber = 9
                    },
                    new
                    {
                        IdBuilding = 9,
                        City = "Poznan",
                        Height = 93.5m,
                        Street = "Sobótki",
                        StreetNumber = 4
                    },
                    new
                    {
                        IdBuilding = 10,
                        City = "Warszawa",
                        Height = 40.4m,
                        Street = "Potulicka",
                        StreetNumber = 45
                    });
            });

            modelBuilder.Entity("AdvertDatabaseCL.Entities.Campaign", b =>
            {
                b.Property<int>("IdCampaign")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime>("EndDate")
                    .HasColumnType("datetime2");

                b.Property<int>("FromIdBuilding")
                    .HasColumnType("int");

                b.Property<int>("IdClient")
                    .HasColumnType("int");

                b.Property<decimal>("PricePerSquareMeter")
                    .HasColumnType("decimal(6,2)");

                b.Property<DateTime>("StartDate")
                    .HasColumnType("datetime2");

                b.Property<int>("ToIdBuilding")
                    .HasColumnType("int");

                b.HasKey("IdCampaign");

                b.HasIndex("FromIdBuilding");

                b.HasIndex("IdClient");

                b.HasIndex("ToIdBuilding");

                b.ToTable("Campaigns");
            });

            modelBuilder.Entity("AdvertDatabaseCL.Entities.Client", b =>
            {
                b.Property<int>("IdClient")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("Hash")
                    .IsRequired()
                    .HasColumnType("nvarchar(44)")
                    .HasMaxLength(44);

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("Login")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("Phone")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("RefreshToken")
                    .HasColumnType("nvarchar(36)")
                    .HasMaxLength(36);

                b.Property<string>("Salt")
                    .IsRequired()
                    .HasColumnType("nvarchar(24)")
                    .HasMaxLength(24);

                b.Property<string>("Token")
                    .HasColumnType("nvarchar(512)")
                    .HasMaxLength(512);

                b.HasKey("IdClient");

                b.HasIndex("Email")
                    .IsUnique();

                b.HasIndex("Login")
                    .IsUnique();

                b.ToTable("Clients");
            });

            modelBuilder.Entity("AdvertDatabaseCL.Configurations.Banner", b =>
            {
                b.HasOne("AdvertDatabaseCL.Entities.Campaign", "Campaign")
                    .WithMany("Banners")
                    .HasForeignKey("IdCampaign")
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();
            });

            modelBuilder.Entity("AdvertDatabaseCL.Entities.Campaign", b =>
            {
                b.HasOne("AdvertDatabaseCL.Entities.Building", "FromBuilding")
                    .WithMany("CampaignsFrom")
                    .HasForeignKey("FromIdBuilding")
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                b.HasOne("AdvertDatabaseCL.Entities.Client", "Client")
                    .WithMany("Campaigns")
                    .HasForeignKey("IdClient")
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                b.HasOne("AdvertDatabaseCL.Entities.Building", "ToBuilding")
                    .WithMany("CampaignsTo")
                    .HasForeignKey("ToIdBuilding")
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();
            });
#pragma warning restore 612, 618
        }
    }
}