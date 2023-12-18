using Booking.UserAccess.Infrastructure;

namespace Booking.API.Startup
{
    public static class ModulesConfiguration
    {
        public static IServiceCollection RegisterModules(this IServiceCollection services,IConfiguration configuration)
        {
            services.ConfigureUserAccessModule(configuration);
            return services;
        }
    }
}
