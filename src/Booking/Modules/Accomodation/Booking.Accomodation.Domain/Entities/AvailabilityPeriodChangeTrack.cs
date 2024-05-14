using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Accomodation.Domain.Entities
{
    public class AvailabilityPeriodChangeTrack : Entity<Guid>
    {
        public DateTimeSlot OldTimeSlot { get; private set; }

        public Money OldPrice { get; private set; }

        public DateTimeSlot NewTimeSlot { get; private set; }

        public Money NewPrice { get; private set; }

        public Guid AvailabilityPeriodId { get; private set; }


    }
}
