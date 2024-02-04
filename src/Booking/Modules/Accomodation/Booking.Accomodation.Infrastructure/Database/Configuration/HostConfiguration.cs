﻿using Booking.Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Booking.Infrastructure.Database.Configuration
{
    internal class HostConfiguration : IEntityTypeConfiguration<Host>
    {
        public void Configure(EntityTypeBuilder<Host> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.UserId).IsUnique();

            builder.HasMany(h => h.Accomodations)
                .WithOne()
                .HasForeignKey(h => h.HostId)
                .IsRequired(true);

            builder.OwnsOne(x => x.Address);
        }
    }
}
