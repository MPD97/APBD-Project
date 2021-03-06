﻿// <auto-generated />
using System;
using Advert.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Advert.Database.Migrations
{
    [DbContext(typeof(AdvertContext))]
    [Migration("20200620123614_AddedMoreBuildingSeedData")]
    partial class AddedMoreBuildingSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Advert.Database.Entities.Banner", b =>
                {
                    b.Property<int>("IdAdvertisment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("Advert.Database.Entities.Building", b =>
                {
                    b.Property<int>("IdBuilding")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                            StreetNumber = 1
                        },
                        new
                        {
                            IdBuilding = 2,
                            City = "Warszawa",
                            Height = 40.2m,
                            Street = "Afrodyty",
                            StreetNumber = 2
                        },
                        new
                        {
                            IdBuilding = 3,
                            City = "Warszawa",
                            Height = 60.3m,
                            Street = "Afrodyty",
                            StreetNumber = 3
                        },
                        new
                        {
                            IdBuilding = 4,
                            City = "Warszawa",
                            Height = 75m,
                            Street = "Afrodyty",
                            StreetNumber = 4
                        },
                        new
                        {
                            IdBuilding = 5,
                            City = "Warszawa",
                            Height = 90.5m,
                            Street = "Afrodyty",
                            StreetNumber = 5
                        },
                        new
                        {
                            IdBuilding = 6,
                            City = "Warszawa",
                            Height = 120m,
                            Street = "Afrodyty",
                            StreetNumber = 6
                        },
                        new
                        {
                            IdBuilding = 7,
                            City = "Warszawa",
                            Height = 23.5m,
                            Street = "Afrodyty",
                            StreetNumber = 7
                        },
                        new
                        {
                            IdBuilding = 8,
                            City = "Warszawa",
                            Height = 30.8m,
                            Street = "Afrodyty",
                            StreetNumber = 8
                        },
                        new
                        {
                            IdBuilding = 9,
                            City = "Warszawa",
                            Height = 88.6m,
                            Street = "Afrodyty",
                            StreetNumber = 9
                        },
                        new
                        {
                            IdBuilding = 10,
                            City = "Warszawa",
                            Height = 132.6m,
                            Street = "Afrodyty",
                            StreetNumber = 10
                        },
                        new
                        {
                            IdBuilding = 11,
                            City = "Warszawa",
                            Height = 35.7m,
                            Street = "Potulicka",
                            StreetNumber = 1
                        },
                        new
                        {
                            IdBuilding = 12,
                            City = "Warszawa",
                            Height = 17.7m,
                            Street = "Potulicka",
                            StreetNumber = 2
                        },
                        new
                        {
                            IdBuilding = 13,
                            City = "Warszawa",
                            Height = 44.5m,
                            Street = "Potulicka",
                            StreetNumber = 3
                        },
                        new
                        {
                            IdBuilding = 14,
                            City = "Warszawa",
                            Height = 39.9m,
                            Street = "Potulicka",
                            StreetNumber = 4
                        },
                        new
                        {
                            IdBuilding = 15,
                            City = "Warszawa",
                            Height = 89.0m,
                            Street = "Potulicka",
                            StreetNumber = 5
                        },
                        new
                        {
                            IdBuilding = 16,
                            City = "Kraków",
                            Height = 133.3m,
                            Street = "Odległa",
                            StreetNumber = 1
                        },
                        new
                        {
                            IdBuilding = 17,
                            City = "Kraków",
                            Height = 166.3m,
                            Street = "Odległa",
                            StreetNumber = 2
                        },
                        new
                        {
                            IdBuilding = 18,
                            City = "Kraków",
                            Height = 45.0m,
                            Street = "Odległa",
                            StreetNumber = 3
                        },
                        new
                        {
                            IdBuilding = 19,
                            City = "Kraków",
                            Height = 44.2m,
                            Street = "Odległa",
                            StreetNumber = 4
                        },
                        new
                        {
                            IdBuilding = 20,
                            City = "Kraków",
                            Height = 12.0m,
                            Street = "Uczniowska",
                            StreetNumber = 1
                        },
                        new
                        {
                            IdBuilding = 21,
                            City = "Kraków",
                            Height = 15.0m,
                            Street = "Uczniowska",
                            StreetNumber = 2
                        },
                        new
                        {
                            IdBuilding = 22,
                            City = "Kraków",
                            Height = 15.0m,
                            Street = "Uczniowska",
                            StreetNumber = 3
                        },
                        new
                        {
                            IdBuilding = 23,
                            City = "Kraków",
                            Height = 18.7m,
                            Street = "Popularna",
                            StreetNumber = 1
                        },
                        new
                        {
                            IdBuilding = 24,
                            City = "Kraków",
                            Height = 18.7m,
                            Street = "Popularna",
                            StreetNumber = 2
                        },
                        new
                        {
                            IdBuilding = 25,
                            City = "Kraków",
                            Height = 18.7m,
                            Street = "Popularna",
                            StreetNumber = 3
                        },
                        new
                        {
                            IdBuilding = 26,
                            City = "Gdańsk",
                            Height = 50.5m,
                            Street = "Portowa",
                            StreetNumber = 1
                        },
                        new
                        {
                            IdBuilding = 27,
                            City = "Gdańsk",
                            Height = 50.5m,
                            Street = "Portowa",
                            StreetNumber = 2
                        },
                        new
                        {
                            IdBuilding = 28,
                            City = "Gdańsk",
                            Height = 50.5m,
                            Street = "Portowa",
                            StreetNumber = 3
                        },
                        new
                        {
                            IdBuilding = 29,
                            City = "Gdańsk",
                            Height = 59.5m,
                            Street = "Portowa",
                            StreetNumber = 4
                        },
                        new
                        {
                            IdBuilding = 30,
                            City = "Gdańsk",
                            Height = 52.2m,
                            Street = "Portowa",
                            StreetNumber = 5
                        },
                        new
                        {
                            IdBuilding = 31,
                            City = "Gdańsk",
                            Height = 54.5m,
                            Street = "Portowa",
                            StreetNumber = 6
                        },
                        new
                        {
                            IdBuilding = 32,
                            City = "Gdańsk",
                            Height = 50.1m,
                            Street = "Portowa",
                            StreetNumber = 7
                        },
                        new
                        {
                            IdBuilding = 33,
                            City = "Poznan",
                            Height = 22.5m,
                            Street = "Sobótki",
                            StreetNumber = 1
                        },
                        new
                        {
                            IdBuilding = 34,
                            City = "Poznan",
                            Height = 25.5m,
                            Street = "Sobótki",
                            StreetNumber = 2
                        },
                        new
                        {
                            IdBuilding = 35,
                            City = "Poznan",
                            Height = 27.5m,
                            Street = "Sobótki",
                            StreetNumber = 3
                        },
                        new
                        {
                            IdBuilding = 36,
                            City = "Poznan",
                            Height = 18.0m,
                            Street = "Sobótki",
                            StreetNumber = 4
                        },
                        new
                        {
                            IdBuilding = 37,
                            City = "Poznan",
                            Height = 22.5m,
                            Street = "Sobótki",
                            StreetNumber = 5
                        },
                        new
                        {
                            IdBuilding = 38,
                            City = "Poznan",
                            Height = 11.5m,
                            Street = "Kolejowa",
                            StreetNumber = 1
                        },
                        new
                        {
                            IdBuilding = 39,
                            City = "Poznan",
                            Height = 12.5m,
                            Street = "Kolejowa",
                            StreetNumber = 2
                        },
                        new
                        {
                            IdBuilding = 40,
                            City = "Poznan",
                            Height = 6.5m,
                            Street = "Kolejowa",
                            StreetNumber = 3
                        });
                });

            modelBuilder.Entity("Advert.Database.Entities.Campaign", b =>
                {
                    b.Property<int>("IdCampaign")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("Advert.Database.Entities.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("Advert.Database.Entities.Banner", b =>
                {
                    b.HasOne("Advert.Database.Entities.Campaign", "Campaign")
                        .WithMany("Banners")
                        .HasForeignKey("IdCampaign")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Advert.Database.Entities.Campaign", b =>
                {
                    b.HasOne("Advert.Database.Entities.Building", "FromBuilding")
                        .WithMany("CampaignsFrom")
                        .HasForeignKey("FromIdBuilding")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Advert.Database.Entities.Client", "Client")
                        .WithMany("Campaigns")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Advert.Database.Entities.Building", "ToBuilding")
                        .WithMany("CampaignsTo")
                        .HasForeignKey("ToIdBuilding")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
