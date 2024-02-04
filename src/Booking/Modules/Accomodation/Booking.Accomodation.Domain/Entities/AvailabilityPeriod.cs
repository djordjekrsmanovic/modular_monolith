using Booking.Accomodation.Domain.ValueObjects;
using Booking.Booking.Domain.ValueObjects;
using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.Entities
{
    public class AvailabilityPeriod : Entity<Guid>
    {
        public DateTimeSlot DateTimeSlot { get; set; }

        public Money Price { get; set; }
        public Guid AccomodationId { get; set; }
    }
}
