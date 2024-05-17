
using Booking.AccommodationNS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.AccommodationNS.Infrastructure.Database.Configuration
{
    internal class AccommodationConfiguration : IEntityTypeConfiguration<Accommodation>
    {

        public void Configure(EntityTypeBuilder<Accommodation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ComplexProperty(x => x.Address);

            builder.ComplexProperty(x => x.PricePerGuest);

            builder.ComplexProperty(x => x.Capacity);

            builder.HasMany(x => x.AdditionalServices)
                .WithMany();

            builder.HasMany(x => x.Reservations)
                .WithOne()
                .HasForeignKey(x => x.AccommodationId)
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
