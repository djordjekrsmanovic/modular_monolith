using Booking.BuildingBlocks.Infrastructure.Extensions;
using Booking.Commerce.Application;
using MassTransit;

namespace Booking.Commerce.Infrastructure
{
    internal class ConsumerConfiguration : IConsumerConfiguration
    {
        public void AddConsumers(IRegistrationConfigurator registrationConfigurator)
        {
            registrationConfigurator.AddConsumer<SubscriberRegisteredIntegrationEventHandler>();
            registrationConfigurator.AddConsumer<PayerRegisteredIntegrationEventHandler>();
        }
    }
}
