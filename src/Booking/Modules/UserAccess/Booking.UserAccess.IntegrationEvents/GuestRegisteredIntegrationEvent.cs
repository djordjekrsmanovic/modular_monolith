using Booking.BuildingBlocks.Application.EventBus;

namespace Booking.UserAccess.IntegrationEvents
{
    public sealed record GuestRegisteredIntegrationEvent(Guid GustId):IntegrationEvent
    {
    }
}
