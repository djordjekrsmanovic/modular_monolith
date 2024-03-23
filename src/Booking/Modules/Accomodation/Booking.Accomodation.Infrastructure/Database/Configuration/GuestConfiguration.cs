
using Booking.Accomodation.Domain.Entities;
using Booking.Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Booking.Infrastructure.Database.Configuration
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

            builder.HasMany(g => g.VisitedAccomodations)
                .WithMany()
                .UsingEntity<GuestVisitedAccomodation>();

            builder.HasMany(g => g.FavouriteAccomodations)
                .WithMany()
                .UsingEntity<GuestFavouriteAccomodation>();

        }
    }
}
