using Booking.AccommodationNS.Infrastructure;
using Booking.Commerce.Infrastructure;
using Booking.UserAccess.Infrastructure;

namespace Booking.API.Startup
{
    public static class ModulesConfiguration
    {
        public static IServiceCollection RegisterModules(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureUserAccessModule(configuration);
            services.ConfigureAccomodationModule(configuration);
            services.ConfigureCommerceModule(configuration);
            return services;
        }
    }
}
