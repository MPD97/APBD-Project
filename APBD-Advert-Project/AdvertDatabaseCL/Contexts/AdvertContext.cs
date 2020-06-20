using System.Diagnostics.CodeAnalysis;
using Advert.Database.Configurations;
using Advert.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Advert.Database.Contexts
{
    public class AdvertContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Banner> Banners { get; set; }


        public AdvertContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected AdvertContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Clients
            modelBuilder.ApplyConfiguration(new ClientsEFConfiguration());

            // Buildings
            modelBuilder.ApplyConfiguration(new BuildingsEFConfiguration());

            // Campaigns
            modelBuilder.ApplyConfiguration(new CampaignsEFConfiguration());

            // Banner
            modelBuilder.ApplyConfiguration(new BannerEFConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
