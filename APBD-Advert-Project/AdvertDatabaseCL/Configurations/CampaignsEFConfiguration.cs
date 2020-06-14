using AdvertDatabaseCL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertDatabaseCL.Configurations
{
    public class CampaignsEFConfiguration : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.HasKey(e => e.IdCampaign);

            builder.Property(e => e.StartDate)
                .IsRequired(true);

            builder.Property(e => e.EndDate)
                .IsRequired(true);

            builder.Property(e => e.PricePerSquareMeter)
                .HasColumnType("decimal(6,2)")
                .IsRequired(true);

            builder.HasOne(e => e.Client).WithMany()
                .HasForeignKey(e => e.IdClient)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.FromBuilding).WithMany()
                .HasForeignKey(e => e.FromIdBuilding)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.ToBuilding).WithMany()
                .HasForeignKey(e => e.ToIdBuilding)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
