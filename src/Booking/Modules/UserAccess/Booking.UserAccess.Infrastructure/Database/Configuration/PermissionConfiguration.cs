using Booking.UserAccess.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionEnum = Booking.BuildingBlocks.Domain.Enums.Permission;
namespace Booking.UserAccess.Infrastructure.Database.Configuration
{
    internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable(nameof(Permission));

            builder.HasKey(x => x.Id);

            IEnumerable<Permission> permissions = Enum.GetValues<PermissionEnum>()
                .Select(p => 
            new Permission
            {
                Id = (int)p,
                Name = p.ToString(),
            });

            builder.HasData(permissions);

        }
    }
}
