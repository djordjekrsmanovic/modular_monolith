using Booking.AccommodationNS.Domain.Errors;
using Booking.BuildingBlocks.Domain;

namespace Booking.AccommodationNS.Domain.Entities
{
    public class Host : Entity<Guid>
    {

        public DateTime SubscriptionExpirationDate { get; private set; }

        public int AccommodationLimit { get; private set; }

        private Host() { }
        private Host(Guid id)
        {
            Id = id;
            SubscriptionExpirationDate = DateTime.Now;
            AccommodationLimit = 1;

        }

        public static Host Create(Guid userId)
        {
            return new Host(userId);
        }

        public Result ExtendSubscription(DateTime newDate, int accommodationLimit)
        {

            if (AccommodationLimit == 1)
            {
                SubscriptionExpirationDate = newDate;
                AccommodationLimit += accommodationLimit;
                return Result.Success();
            }
            return Result.Failure(HostErrors.NotValidAccommodationLimit);

        }

        public bool IsAllowedToCreateAccommodation(int currentAccommodationNumber)
        {
            return currentAccommodationNumber < AccommodationLimit;
        }
    }
}
