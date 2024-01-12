using Booking.BuildingBlocks.Application.EventBus;
using Booking.UserAccess.IntegrationEvents;

namespace Booking.Accomodation.Application
{
    public class ExampleConsumer : IntegrationEventHandler<HostRegisteredIntegrationEvent>
    {
        public override async Task Handle(HostRegisteredIntegrationEvent integrationEvnet, CancellationToken token = default)
        {
            Console.WriteLine("Hello from integration event handler");
        }
    }
}
