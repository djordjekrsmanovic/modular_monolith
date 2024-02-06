namespace Booking.BuildingBlocks.Domain.SharedKernel
{
    public class DateTimeSlot : ValueObject
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }


        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Start;
            yield return End;
        }
    }
}
