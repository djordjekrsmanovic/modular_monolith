using Booking.BuildingBlocks.Infrastructure.Extensions;
using Booking.UserAccess.Application.Features.DeleteUser;
using MassTransit;

namespace Booking.UserAccess.Infrastructure
{
    internal class ConsumerConfiguration : IConsumerConfiguration
    {
        public void AddConsumers(IRegistrationConfigurator registrationConfigurator)
        {
            registrationConfigurator.AddConsumer<DeleteUserIntegrationEventHandler>();
        }
    }
}


