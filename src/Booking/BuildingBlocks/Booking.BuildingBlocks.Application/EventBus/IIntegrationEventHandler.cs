using MassTransit;

namespace Booking.BuildingBlocks.Application.EventBus
{
    public interface IIntegrationEventHandler<in TIntegrationEvent>
        :IConsumer<TIntegrationEvent> where TIntegrationEvent:class,IIntegrationEvent
    {
        Task Handle(TIntegrationEvent integrationEvent,CancellationToken token=default);
    }
}
