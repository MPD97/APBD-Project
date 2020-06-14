using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertDatabaseCL.Configurations
{
    public class BannerEFConfiguration : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.HasKey(e => e.IdAdvertisment);

            builder.Property(e => e.Name)
                .IsRequired(true);

            builder.Property(e => e.Price)
                .HasColumnType("decimal(6,2)")
                .IsRequired(true);

            builder.HasOne(e => e.Campaign).WithMany()
                .HasForeignKey(e => e.IdCampaign)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(e => e.Area)
                .HasColumnType("decimal(6,2)")
                .IsRequired(true);
        }
    }
}
