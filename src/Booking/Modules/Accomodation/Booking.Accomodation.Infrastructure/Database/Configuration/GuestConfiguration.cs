
using Booking.Accomodation.Domain.Entities;
using Booking.AccommodationNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.AccommodationNS.Infrastructure.Database.Configuration
{
    internal class GuestConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(g => g.ReservationRequests)
                .WithOne()
                .HasForeignKey(r => r.GuestId)
                .IsRequired(true);

        }
    }
}
