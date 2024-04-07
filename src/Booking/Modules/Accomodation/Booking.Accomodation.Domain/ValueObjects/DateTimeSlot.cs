using Booking.Accomodation.Domain.Errors;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Domain.ValueObjects
{
    public class DateTimeSlot : ValueObject
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        private DateTimeSlot(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }


        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Start;
            yield return End;
        }

        public bool isInRange(DateTime start, DateTime end)
        {
            return start > Start && end < End;
        }

        public static Result<DateTimeSlot> Create(DateTime start, DateTime end)
        {
            if (start > end)
            {
                return Result.Failure<DateTimeSlot>(DateTimeSlotErrors.TimeSlotInvalid);
            }
            return Result.Success(new DateTimeSlot(start, end));

        }
    }
}
