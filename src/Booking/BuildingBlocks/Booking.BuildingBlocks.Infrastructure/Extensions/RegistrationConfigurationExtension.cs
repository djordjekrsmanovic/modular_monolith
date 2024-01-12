using MassTransit;
using System.Reflection;

namespace Booking.BuildingBlocks.Infrastructure.Extensions
{
    public static class RegistrationConfigurationExtension
    {
        public static void AddConsumersFromAssemblies(this IBusRegistrationConfigurator registrationConfigurator, params Assembly[] assemblies)
        {
            InstanceFactory
                .CreateFromAssemblies<IConsumerConfiguration>(assemblies).ToList()
                .ForEach(consumerInstaller => consumerInstaller.AddConsumers(registrationConfigurator));
        }
    }
}
