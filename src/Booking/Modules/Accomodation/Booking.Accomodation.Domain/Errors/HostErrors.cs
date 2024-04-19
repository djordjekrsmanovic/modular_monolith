using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Domain.Errors
{
    public class HostErrors
    {
        public static readonly Error NotValidAccommodationLimit = new("Host.SubscriptionNotValidAccommodationLimit", "Unable to extend subscription");
    }
}
