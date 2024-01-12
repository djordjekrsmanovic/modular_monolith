using Booking.UserAccess.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.UserAccess.Infrastructure.Database.Configuration
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable(nameof(UserRole));
            builder.HasKey(x => new { x.UserId, x.RoleId });

            builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(userRole => userRole.UserId)
            .IsRequired();

            builder.HasOne<Role>()
                .WithMany()
                .HasForeignKey(userRole => userRole.RoleId)
                .IsRequired();
        }
    }
}
