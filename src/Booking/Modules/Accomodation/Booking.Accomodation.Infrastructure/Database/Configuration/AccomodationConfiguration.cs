
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Booking.Infrastructure.Database.Configuration
{
    internal class AccomodationConfiguration : IEntityTypeConfiguration<Domain.Entities.Accomodation>
    {

        public void Configure(EntityTypeBuilder<Domain.Entities.Accomodation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Address);

            builder.OwnsOne(x => x.PricePerGuest);

            builder.HasMany(x => x.Facilities)
                .WithMany();

            builder.HasMany(x => x.Reservations)
                .WithOne()
                .HasForeignKey(x => x.AccomodationId)
                .IsRequired(true);

            builder.HasMany(x => x.ReservationRequests)
                .WithOne()
                .HasForeignKey(x => x.AccomodationId)
                .IsRequired(true);

            builder.HasMany(x => x.AvailabilityPeriods)
                .WithOne()
                .HasForeignKey(x => x.AccomodationId);

            builder.HasMany(x => x.Photos)
                .WithOne()
                .HasForeignKey(x => x.AccomodationId);


        }
    }
}
