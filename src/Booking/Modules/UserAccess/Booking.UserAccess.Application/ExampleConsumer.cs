using Booking.BuildingBlocks.Application.EventBus;
using Booking.UserAccess.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.UserAccess.Application
{
    public class ExampleConsumer : IntegrationEventHandler<ExampleIntegrationEvent>
    {
        public override async Task Handle(ExampleIntegrationEvent integrationEvnet, CancellationToken token = default)
        {
            Console.WriteLine(integrationEvnet.OccuredOn.ToString());
        }
    }
}
