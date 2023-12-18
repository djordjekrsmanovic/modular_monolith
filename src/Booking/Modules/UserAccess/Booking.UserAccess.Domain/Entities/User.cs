using Booking.BuildingBlocks.Domain;

namespace Booking.UserAccess.Domain.Entities
{
    public class User : Entity<Guid>
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Email { get; init; }

        public string Password { get; init; }

        public bool isActive { get; init; }

        public ICollection<Role> Roles { get; init; }
    }
}
