using Booking.BuildingBlocks.Application.EventBus;

namespace Booking.Accomodation.IntegrationEvents
{
    public sealed record UserDeletedIntegrationEvent(Guid UserId) : IntegrationEvent
    {
    }
}
