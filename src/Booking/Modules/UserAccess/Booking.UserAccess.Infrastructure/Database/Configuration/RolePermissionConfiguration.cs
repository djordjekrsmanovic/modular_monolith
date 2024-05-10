using Booking.UserAccess.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Permission = Booking.BuildingBlocks.Domain.Enums.Permission;


namespace Booking.UserAccess.Infrastructure.Database.Configuration
{
    internal class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(x => new { x.RoleId, x.PermissionId });

            builder.HasData(Create(Role.Host, Permission.GetHostReservations),
                Create(Role.Guest, Permission.GetGuestReservations),
                Create(Role.Host, Permission.HostReservationOperations),
                Create(Role.Host, Permission.HostAccommodationOperations),
                Create(Role.Host, Permission.ChangeUserInfo),
                Create(Role.Guest, Permission.ChangeUserInfo),
                Create(Role.Guest, Permission.GuestReservationOperations));
        }

        private RolePermission Create(Role role, Permission permission)
        {
            return new RolePermission
            {
                RoleId = role.Id,
                PermissionId = (int)permission
            };
        }
    }
}
