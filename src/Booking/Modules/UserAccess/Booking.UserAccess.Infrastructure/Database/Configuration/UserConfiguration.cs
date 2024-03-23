using Booking.UserAccess.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.UserAccess.Infrastructure.Database.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Email).IsUnique();
            builder.HasMany(user => user.Roles)
            .WithMany(role => role.Users)
            .UsingEntity<UserRole>();
            builder.ComplexProperty(user => user.Address);
        }
    }
}
