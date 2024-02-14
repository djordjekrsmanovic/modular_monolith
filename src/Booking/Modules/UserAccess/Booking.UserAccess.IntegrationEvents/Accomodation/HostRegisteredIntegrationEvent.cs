using Booking.BuildingBlocks.Application.EventBus;

namespace Booking.UserAccess.IntegrationEvents.Accomodation
{
    public sealed record HostRegisteredIntegrationEvent(Guid HostId) : IntegrationEvent
    {

    }
}
