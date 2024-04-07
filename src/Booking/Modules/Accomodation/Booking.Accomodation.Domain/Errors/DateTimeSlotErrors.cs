using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Domain.Errors
{
    public class DateTimeSlotErrors
    {
        public static readonly Error TimeSlotInvalid = new("DateTimeSlot.InvalidTimeSlot", "Time slot is not valid");
    }
}
