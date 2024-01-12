using Booking.BuildingBlocks.Application.EventBus;

namespace Booking.UserAccess.IntegrationEvents
{
    public record ExampleIntegrationEvent(Guid Id,DateTime OccuredOn):IntegrationEvent(Id, OccuredOn)
    {

    }
}
