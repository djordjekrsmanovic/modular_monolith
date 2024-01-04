using Booking.UserAccess.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Booking.UserAccess.Infrastructure.Database.Configuration
{
    internal class RegistrationRequestConfiguration : IEntityTypeConfiguration<RegistrationRequest>
    {
        public void Configure(EntityTypeBuilder<RegistrationRequest> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable(nameof(RegistrationRequest));

            builder.ComplexProperty(x => x.Status);
        }
    }
}
