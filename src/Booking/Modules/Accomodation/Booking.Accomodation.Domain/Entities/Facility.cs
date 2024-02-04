using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.Entities
{
    public class Facility : Entity<Guid>
    {
        public string Name { get; set; }
    }
}
