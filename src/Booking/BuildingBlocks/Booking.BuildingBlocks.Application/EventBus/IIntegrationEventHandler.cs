using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.BuildingBlocks.Application.EventBus
{
    public interface IIntegrationEventHandler<in TIntegrationEvent>:IConsumer where TIntegrationEvent:IIntegrationEvent
    {
        Task Handle(TIntegrationEvent integrationEvent,CancellationToken token=default);
    }
}
