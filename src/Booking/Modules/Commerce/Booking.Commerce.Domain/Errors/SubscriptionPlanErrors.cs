using Booking.BuildingBlocks.Domain;

namespace Booking.Commerce.Domain.Errors
{
    public class SubscriptionPlanErrors
    {
        public static readonly Error SubscriptionPlanNotExist = new("SubscriptionPlan.SubscriptionPlanNotExist", "Subscription plan does not exist");
    }
}
