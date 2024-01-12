using Booking.BuildingBlocks.Application.EventBus;
using MassTransit;

namespace Booking.BuildingBlocks.Infrastructure.EventBus
{
    public class EventBus : IEventBus
    {
        private readonly IBus _bus;

        public EventBus(IBus bus)
        {
            _bus = bus;
        }

        public async Task PublishAsync<TIntegrationEvent>(TIntegrationEvent integrationEvent, CancellationToken cancellationToken = default) where TIntegrationEvent : IIntegrationEvent
        {
            await _bus.Publish(integrationEvent, cancellationToken);
        }
    }
}
