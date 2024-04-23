using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Booking.Domain.Entities
{
    public class Reservation : Entity<Guid>
    {
        public DateTimeSlot DateTimeSlot { get; set; }

        public int GuestNumber { get; set; }

        public Money Price { get; set; }

        public Guid GustId { get; set; }

        public Guid AccomodationId { get; set; }

        public Guid? ReservationRequestId { get; set; }
    }
}
