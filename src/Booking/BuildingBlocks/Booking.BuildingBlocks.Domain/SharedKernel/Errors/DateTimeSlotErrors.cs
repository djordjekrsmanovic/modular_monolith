namespace Booking.BuildingBlocks.Domain.SharedKernel.Errors
{
    public class DateTimeSlotErrors
    {
        public static readonly Error TimeSlotInvalid = new("DateTimeSlot.InvalidTimeSlot", "Time slot is not valid");
    }
}
