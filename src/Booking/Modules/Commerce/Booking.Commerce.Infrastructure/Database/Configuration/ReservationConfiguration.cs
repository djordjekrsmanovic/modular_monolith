using Booking.Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Commerce.Infrastructure.Database.Configuration
{
    internal class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ComplexProperty(x => x.Price);

            builder.HasMany(x => x.Payments).WithOne().HasForeignKey(x => x.ReservationId);
        }
    }
}
