using Booking.BuildingBlocks.Application.EventBus;
using Booking.BuildingBlocks.Domain.Enums;

namespace Booking.Booking.IntegrationEvents
{
    public record ReservationCreatedIntegrationEvent(Guid ReservationId, double Amount, Currency Currency) : IntegrationEvent
    {

    }
}
