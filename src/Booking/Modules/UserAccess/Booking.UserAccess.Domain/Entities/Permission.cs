using Booking.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.UserAccess.Domain.Entities
{
    public class Permission : Entity<int>
    {
        public string Name { get; init; } = string.Empty;

    }
}
