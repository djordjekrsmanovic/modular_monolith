using Booking.Booking.Domain.Enums;
using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Booking.Domain.Entities
{
    public class ReservationRequest : AgregateRoot<Guid>
    {
        public DateTimeSlot DateTimeSlot { get; set; }

        public ReservationRequestStatus Status { get; set; }

        public int GuestNumber { get; set; }

        public string? Message { get; set; }

        public Guid GuestId { get; set; }

        public Guid AccomodationId { get; set; }
    }
}
