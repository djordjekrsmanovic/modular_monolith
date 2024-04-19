namespace Booking.Commerce.Application.Features.SubscriptionPlans.Get
{
    public record SubscriptionPlanResponse(Guid Id, string Name, string Description, string Price, int Duration, int AccommodationLimit)
    {
    }
}
