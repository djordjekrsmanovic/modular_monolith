using Booking.BuildingBlocks.Application.EventBus;

namespace Booking.UserAccess.IntegrationEvents.Commerce
{
    public sealed record PayerRegisteredIntegrationEvent(Guid GustId) : IntegrationEvent
    {
    }
}
