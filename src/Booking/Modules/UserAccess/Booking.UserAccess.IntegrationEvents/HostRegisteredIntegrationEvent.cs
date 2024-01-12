using Booking.BuildingBlocks.Application.EventBus;

namespace Booking.UserAccess.IntegrationEvents
{
    public sealed record HostRegisteredIntegrationEvent(Guid HostId):IntegrationEvent
    {

    }
}
