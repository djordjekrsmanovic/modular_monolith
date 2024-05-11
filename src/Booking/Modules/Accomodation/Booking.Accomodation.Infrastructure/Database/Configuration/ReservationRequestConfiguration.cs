using Booking.AccommodationNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Accomodation.Infrastructure.Database.Configuration
{
    internal class ReservationRequestConfiguration : IEntityTypeConfiguration<ReservationRequest>
    {
        public void Configure(EntityTypeBuilder<ReservationRequest> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ComplexProperty(x => x.Slot);

            builder.ComplexProperty(x => x.Price);

            builder.HasOne<Accommodation>().WithMany().HasForeignKey(x => x.AccomodationId);

        }
    }
}
