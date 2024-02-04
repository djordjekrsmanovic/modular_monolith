using Booking.Accomodation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Accomodation.Infrastructure.Database.Configuration
{
    internal class PriceChangeTrackConfiguration : IEntityTypeConfiguration<PriceChangeTrack>
    {
        public void Configure(EntityTypeBuilder<PriceChangeTrack> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.OldPrice);

            builder.OwnsOne(x => x.NewPrice);

        }
    }
}
