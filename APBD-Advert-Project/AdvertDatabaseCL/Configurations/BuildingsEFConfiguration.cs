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
        }
    }
}
