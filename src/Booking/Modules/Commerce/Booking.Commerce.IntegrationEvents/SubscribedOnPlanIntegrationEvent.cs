using Booking.BuildingBlocks.Application.EventBus;

namespace Booking.Commerce.IntegrationEvents
{
    public record SubscribedOnPlanIntegrationEvent(Guid SubscriberId, int AccommodationLimit, DateTime SubscriptionExpirationDate) : IntegrationEvent
    {

    }
}
