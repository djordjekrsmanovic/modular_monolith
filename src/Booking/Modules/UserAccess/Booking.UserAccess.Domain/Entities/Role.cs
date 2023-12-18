using Booking.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.UserAccess.Domain.Entities
{
    public class Role : Enumeration<Role>
    {

        public static readonly Role Host = new(1, "Host");

        public static readonly Role Guest = new(2, "Guest");

        public Role(int id,string name): base(id,name) { }
        
        public ICollection<Permission> Permissions { get; init; }

        public ICollection<User> Users { get; init; }
    }
}
