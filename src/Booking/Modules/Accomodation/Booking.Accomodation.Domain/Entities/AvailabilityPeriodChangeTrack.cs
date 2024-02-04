using Booking.Accomodation.Domain.ValueObjects;
using Booking.Booking.Domain.ValueObjects;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Domain.Entities
{
    public class AvailabilityPeriodChangeTrack : Entity<Guid>
    {
        public DateTimeSlot OldTimeSlot { get; set; }

        public Money OldPrice { get; set; }

        public DateTimeSlot NewTimeSlot { get; set; }

        public Money NewPrice { get; set; }

        public Guid AvailabilityPeriodId { get; set; }


    }
}
