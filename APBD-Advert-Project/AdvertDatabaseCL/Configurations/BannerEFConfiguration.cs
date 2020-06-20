using Advert.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Advert.Database.Configurations
{
    public class BannerEFConfiguration : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.HasKey(e => e.IdAdvertisment);

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.Price)
                .HasColumnType("decimal(6,2)")
                .IsRequired();

            builder.HasOne(e => e.Campaign).WithMany(c => c.Banners)
                .HasForeignKey(e => e.IdCampaign)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(e => e.Area)
                .HasColumnType("decimal(6,2)")
                .IsRequired();
        }
    }
}