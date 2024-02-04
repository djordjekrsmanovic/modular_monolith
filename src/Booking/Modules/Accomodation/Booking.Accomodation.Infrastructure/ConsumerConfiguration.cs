using Booking.Booking.Application;
using Booking.BuildingBlocks.Infrastructure.Extensions;
using MassTransit;

namespace Booking.Booking.Infrastructure
{
    internal class ConsumerConfiguration : IConsumerConfiguration
    {
        public void AddConsumers(IRegistrationConfigurator registrationConfigurator)
        {
            registrationConfigurator.AddConsumer<ExampleConsumer>();
        }
    }
}
