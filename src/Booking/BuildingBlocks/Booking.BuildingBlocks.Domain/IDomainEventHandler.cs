using MediatR;


namespace Booking.BuildingBlocks.Domain
{
    public interface IDomainEventHandler<in TEvent> : INotificationHandler<TEvent>
        where TEvent : DomainEvent
    {
    }
}
