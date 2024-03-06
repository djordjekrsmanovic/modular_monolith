using Booking.Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Commerce.Infrastructure.Database.Configuration
{
    internal class PayerConfiguration : IEntityTypeConfiguration<Payer>
    {
        public void Configure(EntityTypeBuilder<Payer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.PayerId).IsUnique();

            builder.HasMany(x => x.Invoices)
                .WithOne();

        }
    }
}
