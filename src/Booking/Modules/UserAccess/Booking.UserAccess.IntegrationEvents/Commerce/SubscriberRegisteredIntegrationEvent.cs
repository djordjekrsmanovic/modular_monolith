using Booking.BuildingBlocks.Application.EventBus;

namespace Booking.UserAccess.IntegrationEvents.Commerce
{
    public sealed record SubscriberRegisteredIntegrationEvent(Guid HostId) : IntegrationEvent
    {
    }
}
