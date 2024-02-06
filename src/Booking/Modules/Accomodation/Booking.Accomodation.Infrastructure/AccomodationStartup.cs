using Booking.Accomodation.Infrastructure.Database;
using Booking.Booking.Infrastructure.Database;
using Booking.BuildingBlocks.Application.EventBus;
using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Infrastructure.EventBus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Booking.Infrastructure
{
    public static class AccomodationStartup
    {
        public static IServiceCollection ConfigureAccomodationModule
        (this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration["DatabaseConfig:ConnectionString"];
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies([Application.AssemblyReference.Assembly]));

            SetUpServices(services);
            SetUpDatabase(services, connectionString);

            return services;
        }

        private static void SetUpServices(IServiceCollection services)
        {

            services.AddScoped<IEventBus, EventBus>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void SetUpDatabase(IServiceCollection services, string connectionString)
        {
            Console.Write(connectionString);
            services.AddDbContext<AccomodationDbContext>(options =>
                options.UseSqlServer(connectionString, x => x.MigrationsHistoryTable("__MigrationHistory", "accomodation")));

        }
    }



}

