using Booking.Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Commerce.Infrastructure.Database.Configuration
{
    internal class ReservationPaymentConfiguration : IEntityTypeConfiguration<ReservationPayment>
    {
        public void Configure(EntityTypeBuilder<ReservationPayment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ComplexProperty(x => x.Amount);
        }

    }
}
