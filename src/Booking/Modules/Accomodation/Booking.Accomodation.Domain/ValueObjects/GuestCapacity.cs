using Booking.Accomodation.Domain.Errors;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Domain.ValueObjects
{
    public class GuestCapacity : ValueObject
    {
        public int MinGuestNumber { get; private set; }

        public int MaxGuestNumber { get; private set; }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return MinGuestNumber;
            yield return MaxGuestNumber;
        }

        private GuestCapacity() { }

        private GuestCapacity(int minGuestNumber, int maxGuestNumber)
        {
            MinGuestNumber = minGuestNumber;
            MaxGuestNumber = maxGuestNumber;
        }

        public static Result<GuestCapacity> Create(int minGuestNumber, int maxGuestNumber)
        {
            if (minGuestNumber < 1 || maxGuestNumber < 1)
            {
                return Result.Failure<GuestCapacity>(GuestCapacityErrors.InvalidCapacityValues);
            }

            if (minGuestNumber > maxGuestNumber)
            {
                return Result.Failure<GuestCapacity>(GuestCapacityErrors.WrongCapacityValues);
            }

            return Result.Success(new GuestCapacity(minGuestNumber, maxGuestNumber));

        }
    }
}
