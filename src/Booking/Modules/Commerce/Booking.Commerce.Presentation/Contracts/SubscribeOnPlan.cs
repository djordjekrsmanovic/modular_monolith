namespace Booking.Commerce.Presentation.Contracts
{
    public record SubscribeOnPlan(Guid SubscriberId, Guid SubscriptionPlanId, string PaymentMethod)
    {
    }
}
