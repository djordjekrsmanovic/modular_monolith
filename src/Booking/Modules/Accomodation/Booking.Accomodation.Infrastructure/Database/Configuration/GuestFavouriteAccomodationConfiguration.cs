using Booking.Accomodation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Accomodation.Infrastructure.Database.Configuration
{
    internal class GuestFavouriteAccomodationConfiguration
        : IEntityTypeConfiguration<GuestFavouriteAccomodation>
    {
        public void Configure(EntityTypeBuilder<GuestFavouriteAccomodation> builder)
        {
            builder.HasKey(x => new { x.AccomodationId, x.GuestId });
        }
    }
}
