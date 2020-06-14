using AdvertDatabaseCL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AdvertDatabaseCL.Contexts
{
    public class AdvertContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public AdvertContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected AdvertContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
