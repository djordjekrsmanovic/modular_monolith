using MassTransit;

namespace Booking.BuildingBlocks.Infrastructure.Extensions
{
    public interface IConsumerConfiguration
    {
        void AddConsumers(IRegistrationConfigurator registrationConfigurator);
    }
}
