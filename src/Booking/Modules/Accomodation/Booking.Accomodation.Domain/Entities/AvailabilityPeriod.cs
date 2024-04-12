using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Booking.Domain.Entities
{
    public class AvailabilityPeriod : Entity<Guid>
    {
        public DateTimeSlot Slot { get; set; }

        public Money Price { get; set; }
        public Guid AccommodationId { get; set; }

        private AvailabilityPeriod() { }

        private AvailabilityPeriod(DateTimeSlot slot, Money price, Guid accommodationId)
        {
            Slot = slot;
            Price = price;
            AccommodationId = accommodationId;
        }

        public static Result<AvailabilityPeriod> Create(DateTime start, DateTime end, Money price, Guid accommodationId)
        {
            Result<DateTimeSlot> slotResult = DateTimeSlot.Create(start, end);

            if (slotResult.IsFailure)
            {
                return Result.Failure<AvailabilityPeriod>(slotResult.Error);
            }

            return new AvailabilityPeriod(slotResult.Value, price, accommodationId);
        }
    }
}
