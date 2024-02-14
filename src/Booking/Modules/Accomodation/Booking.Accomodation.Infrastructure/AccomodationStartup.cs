using Booking.Accomodation.Domain;
using Booking.Accomodation.Domain.Repositories;
using Booking.Accomodation.Infrastructure.Database;
using Booking.Accomodation.Infrastructure.Database.Repositories;
using Booking.Booking.Infrastructure.Database;
using Booking.BuildingBlocks.Application.EventBus;
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
            string connectionString = "Server=NHL2131W;Database=Booking;Trusted_Connection=True;TrustServerCertificate=True;";
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies([Application.AssemblyReference.Assembly]));

            SetUpServices(services);
            SetUpDatabase(services, connectionString);

            return services;
        }

        private static void SetUpServices(IServiceCollection services)
        {

            services.AddTransient<IEventBus, EventBus>();

        }

        private static void SetUpDatabase(IServiceCollection services, string connectionString)
        {
            Console.Write(connectionString);
            services.AddDbContext<AccomodationDbContext>(options =>
                options.UseSqlServer(connectionString, x => x.MigrationsHistoryTable("__MigrationHistory", "accomodation")), ServiceLifetime.Scoped);
            services.AddScoped<IHostRepository, HostRepository>();
            services.AddScoped<IGuestRepository, GuestRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }



}

