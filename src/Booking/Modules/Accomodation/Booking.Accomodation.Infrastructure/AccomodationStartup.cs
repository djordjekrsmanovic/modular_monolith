using Booking.BuildingBlocks.Application.EventBus;
using Booking.BuildingBlocks.Infrastructure.EventBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Accomodation.Infrastructure
{
    public static class AccomodationStartup
    {
        public static IServiceCollection ConfigureAccomodationModule
        (this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration["DatabaseConfig:ConnectionString"];
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies([Application.AssemblyReference.Assembly]));

            SetUpServices(services);
            //SetUpDatabase(services, connectionString);
            //SetUpAuthentication(services);
            

            return services;
        }

        private static void SetUpServices(IServiceCollection services)
        {
            
            services.AddScoped<IEventBus, EventBus>();
        }

        /*private static void SetUpDatabase(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<UserAccessDbContext>(options =>
            options.UseSqlServer(connectionString,
            x => x.MigrationsHistoryTable("__MigrationHistory", "user_access")));
            
        }*/
    }
    


}

