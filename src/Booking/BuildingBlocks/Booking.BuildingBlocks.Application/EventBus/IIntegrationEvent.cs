namespace Booking.BuildingBlocks.Application.EventBus
{
    public interface IIntegrationEvent
    {
        Guid Id { get; }

        DateTime OccurredOn { get; }
    }
}
