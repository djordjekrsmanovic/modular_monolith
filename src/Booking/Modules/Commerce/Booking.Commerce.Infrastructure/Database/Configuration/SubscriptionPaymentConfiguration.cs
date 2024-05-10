﻿using Booking.Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Commerce.Infrastructure.Database.Configuration
{
    internal class SubscriptionPaymentConfiguration : IEntityTypeConfiguration<SubscriptionPayment>
    {
        public void Configure(EntityTypeBuilder<SubscriptionPayment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ComplexProperty(x => x.Amount);
        }
    }
}
