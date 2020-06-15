﻿// <auto-generated />
using System;
using AdvertDatabaseCL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdvertDatabaseCL.Migrations
{
    [DbContext(typeof(AdvertContext))]
    [Migration("20200615114909_EmailAndLoginChangedToUniqeInClientsTable")]
    partial class EmailAndLoginChangedToUniqeInClientsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("AdvertDatabaseCL.Entities.Building", b =>
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
                });

            modelBuilder.Entity("AdvertDatabaseCL.Entities.Campaign", b =>
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

            modelBuilder.Entity("AdvertDatabaseCL.Entities.Client", b =>
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

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

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
