using Booking.BuildingBlocks.Domain;

namespace Booking.UserAccess.Domain.Entities
{
    public class Permission : Entity<int>
    {
        public string Name { get; init; } = string.Empty;

    }
}
