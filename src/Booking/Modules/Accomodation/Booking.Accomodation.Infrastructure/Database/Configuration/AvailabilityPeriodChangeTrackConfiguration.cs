using Booking.Accomodation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Accomodation.Infrastructure.Database.Configuration
{
    internal class AvailabilityPeriodChangeTrackConfiguration :
        IEntityTypeConfiguration<AvailabilityPeriodChangeTrack>
    {
        public void Configure(EntityTypeBuilder<AvailabilityPeriodChangeTrack> builder)
        {
            builder.HasKey(a => a.Id);

            builder.OwnsOne(a => a.NewPrice);

            builder.OwnsOne(a => a.OldPrice);

            builder.OwnsOne(a => a.NewTimeSlot);

            builder.OwnsOne(a => a.OldTimeSlot);
        }
    }
}
