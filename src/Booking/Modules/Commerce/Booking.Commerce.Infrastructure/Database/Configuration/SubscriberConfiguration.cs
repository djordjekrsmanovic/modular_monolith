using Booking.Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Commerce.Infrastructure.Database.Configuration
{
    internal class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.HostId).IsUnique();

            builder.HasMany(x => x.Subscriptions)
                .WithOne();

            builder.HasMany(x => x.Invoices)
                .WithOne();
        }
    }
}
