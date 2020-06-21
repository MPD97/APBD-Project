using Advert.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Advert.Database.Configurations
{
    public class CampaignsEFConfiguration : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.HasKey(e => e.IdCampaign);

            builder.Property(e => e.StartDate)
                .IsRequired();

            builder.Property(e => e.EndDate)
                .IsRequired();

            builder.Property(e => e.PricePerSquareMeter)
                .HasColumnType("decimal(6,2)")
                .IsRequired();

            builder.HasOne(e => e.Client).WithMany(c => c.Campaigns)
                .HasForeignKey(e => e.IdClient)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.FromBuilding).WithMany(b => b.CampaignsFrom)
                .HasForeignKey(e => e.FromIdBuilding)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.ToBuilding).WithMany(b => b.CampaignsTo)
                .HasForeignKey(e => e.ToIdBuilding)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}