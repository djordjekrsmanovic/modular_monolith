using Booking.BuildingBlocks.Application.EventBus;

namespace Booking.UserAccess.IntegrationEvents.Accomodation
{
    public sealed record GuestRegisteredIntegrationEvent(Guid GustId) : IntegrationEvent
    {
    }
}
