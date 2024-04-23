
using Booking.Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Booking.Infrastructure.Database.Configuration
{
    internal class AccommodationConfiguration : IEntityTypeConfiguration<Domain.Entities.Accommodation>
    {

        public void Configure(EntityTypeBuilder<Domain.Entities.Accommodation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ComplexProperty(x => x.Address);

            builder.ComplexProperty(x => x.PricePerGuest);

            builder.ComplexProperty(x => x.Capacity);

            builder.HasMany(x => x.AdditionalServices)
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
                .HasForeignKey(x => x.AccommodationId);

            builder.HasMany(x => x.Images)
                .WithOne()
                .HasForeignKey(x => x.AccomodationId);

            builder.HasOne<Host>().WithMany().HasForeignKey(x => x.HostId);

        }
    }
}
