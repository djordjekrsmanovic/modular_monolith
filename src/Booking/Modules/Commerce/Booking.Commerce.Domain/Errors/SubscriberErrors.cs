using Booking.BuildingBlocks.Domain;

namespace Booking.Commerce.Domain.Errors
{
    public class SubscriberErrors
    {
        public static readonly Error SubscriberNotExist = new("Subscriber.SubscriberNotExist", "Subscriber does not exist");
    }
}
