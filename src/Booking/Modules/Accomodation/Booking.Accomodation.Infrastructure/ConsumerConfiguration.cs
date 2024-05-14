using Booking.AccommodationNS.Application.Features.Guests;
using Booking.AccommodationNS.Application.Features.Hosts;
using Booking.BuildingBlocks.Infrastructure.Extensions;
using MassTransit;

namespace Booking.AccommodationNS.Infrastructure
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
