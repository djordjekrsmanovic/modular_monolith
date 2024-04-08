using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.Entities
{
    public class Review : Entity<Guid>
    {
        public int Rating { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid AccomodationId { get; set; }

        public Guid GuestId { get; set; }
    }
}
