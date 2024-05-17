using Booking.BuildingBlocks.Domain;

namespace Booking.AccommodationNS.Domain.Errors
{
    public class HostErrors
    {
        public static readonly Error NotValidAccommodationLimit = new("Host.SubscriptionNotValidAccommodationLimit", "Unable to extend subscription");

        public static readonly Error UnableToDeleteHost = new("Host.UnableToDeleteHost", "Unable to delete host");
    }
}
