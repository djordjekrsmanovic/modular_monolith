namespace Booking.BuildingBlocks.Application.EventBus
{
    public abstract record IntegrationEvent(Guid Id,DateTime OccuredOn):IIntegrationEvent
    {
    }
}
