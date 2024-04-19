using Booking.Accomodation.Domain.Errors;
using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.Entities
{
    public class Host : Entity<Guid>
    {
        public List<Accommodation> Accommodations { get; private set; }

        public DateTime SubscriptionExpirationDate { get; private set; }

        public int AccommodationLimit { get; private set; }

        private Host() { }
        private Host(Guid id)
        {
            Id = id;
            Accommodations = new List<Accommodation>();
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

        public bool IsAllowedToCreateAccommodation()
        {
            return Accommodations.Count < AccommodationLimit;
        }
    }
}
