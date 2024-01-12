using Booking.Accomodation.Application;
using Booking.BuildingBlocks.Infrastructure.Extensions;
using MassTransit;

namespace Booking.Accomodation.Infrastructure
{
    internal class ConsumerConfiguration : IConsumerConfiguration
    {
        public void AddConsumers(IRegistrationConfigurator registrationConfigurator)
        {
            registrationConfigurator.AddConsumer<ExampleConsumer>();
        }
    }
}
