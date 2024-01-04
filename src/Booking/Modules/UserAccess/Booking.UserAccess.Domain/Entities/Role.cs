using Booking.BuildingBlocks.Domain;

namespace Booking.UserAccess.Domain.Entities
{
    public class Role : Enumeration<Role>,IStaticEntity
    {

        public static readonly Role Host = new(1, "Host");

        public static readonly Role Guest = new(2, "Guest");

        private Role() { }

        public Role(int id,string name): base(id,name) { }
        
        public ICollection<Permission> Permissions { get; init; }

        public IReadOnlyCollection<User> Users { get; } = new List<User>();
    }
}
