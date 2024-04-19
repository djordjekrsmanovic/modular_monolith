using Booking.Accomodation.Application.Features.Guests;
using Booking.Accomodation.Application.Features.Hosts;
using Booking.BuildingBlocks.Infrastructure.Extensions;
using MassTransit;

namespace Booking.Booking.Infrastructure
{
    internal class ConsumerConfiguration : IConsumerConfiguration
    {
        public void AddConsumers(IRegistrationConfigurator registrationConfigurator)
        {
            registrationConfigurator.AddConsumer<HostRegisteredIntegrationEventHandler>();
            registrationConfigurator.AddConsumer<GuestRegisteredIntegrationEventHandler>();
            registrationConfigurator.AddConsumer<SubscribedOnPlanIntegrationEventHandler>();
        }
    }
}
