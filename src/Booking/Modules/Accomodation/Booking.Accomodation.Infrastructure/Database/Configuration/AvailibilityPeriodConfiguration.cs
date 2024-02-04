using Booking.Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Accomodation.Infrastructure.Database.Configuration
{
    internal class AvailibilityPeriodConfiguration : IEntityTypeConfiguration<AvailabilityPeriod>
    {
        public void Configure(EntityTypeBuilder<AvailabilityPeriod> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Price);

            builder.OwnsOne(x => x.DateTimeSlot);
        }
    }
}
