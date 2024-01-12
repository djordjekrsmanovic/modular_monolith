using System.Runtime.InteropServices;

namespace Booking.BuildingBlocks.Application.EventBus
{
    public abstract class IntegrationEventHandler<TIntegrationEvnet> : IIntegrationEventHandler<TIntegrationEvnet>
        where TIntegrationEvnet : IIntegrationEvent
    {
        public abstract Task Handle(TIntegrationEvnet integrationEvnet,CancellationToken token=default);
        
    }
}
