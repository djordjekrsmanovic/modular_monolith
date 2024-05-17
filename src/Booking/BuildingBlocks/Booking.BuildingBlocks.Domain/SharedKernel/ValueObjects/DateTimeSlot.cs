using Booking.BuildingBlocks.Domain.SharedKernel.Errors;

namespace Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects
{
    public class DateTimeSlot : ValueObject
    {
        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }

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

        public bool IsSlotInProvidedRange(DateTime start, DateTime end)
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

        public bool IsDateInSlot(DateTime date)
        {
            return date >= Start && date <= End;
        }

        public bool IsSlotOverlaping(DateTimeSlot slot)
        {
            return IsDateInSlot(slot.Start) || IsDateInSlot(slot.End);
        }

        public int GetNumberOfDays()
        {
            TimeSpan difference = End - Start;

            return (int)difference.TotalDays;
        }

        public bool IsDateBeforeSlot(DateTime date)
        {
            return date < Start;
        }
    }
}
