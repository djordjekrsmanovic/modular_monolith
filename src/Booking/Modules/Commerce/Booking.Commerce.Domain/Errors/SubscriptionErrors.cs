using Booking.BuildingBlocks.Domain;

namespace Booking.Commerce.Domain.Errors
{
    public class SubscriptionErrors
    {
        public static readonly Error UserAlreadySubscribed = new("Subscription.UserAlreadySubscribed", "User is already subscribed on plan");
        public static readonly Error SubscriptionPaymentAlreadyExist = new("SubscriptionPayment.PaymentAlreadyExist", "Subscripton payment already exists");
        public static readonly Error SubscriptionNotExist = new("Subscription.SubscriptionNotExist", "Subscription with provided id not exist");
    }
}
