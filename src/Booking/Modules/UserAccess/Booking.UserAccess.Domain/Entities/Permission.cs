using Booking.BuildingBlocks.Domain;

namespace Booking.UserAccess.Domain.Entities
{
    public class Permission : Entity<int>
    {
        private Permission() { }

        private Permission(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Result<Permission> Create(int id, string name)
        {
            return Result.Success(new Permission(id, name));
        }
        public string Name { get; private set; } = string.Empty;

    }
}
