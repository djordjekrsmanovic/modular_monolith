using Booking.Accomodation.Domain.ValueObjects;
using Booking.Booking.Domain.ValueObjects;
using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.Entities
{
    public class Reservation : Entity<Guid>
    {
        public DateTimeSlot DateTimeSlot { get; set; }

        public int GuestNumber { get; set; }

        public Money Price { get; set; }

        public Guid GustId { get; set; }

        public Guid AccomodationId { get; set; }
    }
}
