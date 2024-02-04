using Booking.Accomodation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Accomodation.Infrastructure.Database.Configuration
{
    internal class GuestVisitedAccomodationConfiguration
        : IEntityTypeConfiguration<GuestVisitedAccomodation>
    {
        public void Configure(EntityTypeBuilder<GuestVisitedAccomodation> builder)
        {
            builder.HasKey(x => new { x.GuestId, x.AccomodationId });
        }
    }
}
