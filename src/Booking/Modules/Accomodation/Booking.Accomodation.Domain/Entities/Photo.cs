using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.Entities
{
    public class Photo : Entity<Guid>
    {
        public string Name { get; set; }

        public Byte[] Content { get; set; }

        public Guid AccomodationId { get; set; }
    }
}
