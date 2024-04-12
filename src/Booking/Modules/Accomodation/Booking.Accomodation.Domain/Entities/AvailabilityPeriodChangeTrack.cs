using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

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
