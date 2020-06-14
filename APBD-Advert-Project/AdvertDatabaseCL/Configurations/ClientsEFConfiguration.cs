﻿using AdvertDatabaseCL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertDatabaseCL.Configurations
{
    class ClientsEFConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e => e.IdClient);

            builder.Property(e => e.FirstName)
              .HasMaxLength(100)
              .IsRequired(true);

            builder.Property(e => e.LastName)
              .HasMaxLength(100)
              .IsRequired(true);

            builder.Property(e => e.Email)
              .HasMaxLength(100)
              .IsRequired(true);

            builder.Property(e => e.Phone)
              .HasMaxLength(100)
              .IsRequired(true);

            builder.Property(e => e.Login)
              .HasMaxLength(100)
              .IsRequired(true);
        }
    }
}