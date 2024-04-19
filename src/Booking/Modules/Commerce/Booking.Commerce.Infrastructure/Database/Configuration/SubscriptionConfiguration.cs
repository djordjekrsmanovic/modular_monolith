using Booking.Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Commerce.Infrastructure.Database.Configuration
{
    internal class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ComplexProperty(x => x.SubscriptionPeriod);

            builder.HasOne(x => x.Plan);

            builder.HasMany(x => x.Payments).WithOne().HasForeignKey(x => x.ProductId);
        }
    }
}
