namespace Booking.Commerce.Application.Features.SubscriptionPlans.Get
{
    public record GetSubscriptionPlanResponse(Guid Id, string Name, string Description, string Price, int Duration, int AccommodationLimit)
    {
    }
}
