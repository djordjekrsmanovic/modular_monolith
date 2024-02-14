using MassTransit;

namespace Booking.BuildingBlocks.Application.EventBus
{
    public abstract class IntegrationEventHandler<TIntegrationEvnet> : IIntegrationEventHandler<TIntegrationEvnet>
        where TIntegrationEvnet : class, IIntegrationEvent
    {
        public async Task Consume(ConsumeContext<TIntegrationEvnet> context)
        {
            Handle(context.Message, default);
        }

        public abstract Task Handle(TIntegrationEvnet integrationEvnet, CancellationToken token = default);

    }
}
