using Booking.AccommodationNS.Domain;
using Booking.AccommodationNS.Domain.Repositories;
using Booking.AccommodationNS.Infrastructure.Database;
using Booking.AccommodationNS.Infrastructure.Database.Repositories;
using Booking.BuildingBlocks.Application.EventBus;
using Booking.BuildingBlocks.Infrastructure.EventBus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.AccommodationNS.Infrastructure
{
    public static class AccomodationStartup
    {
        public static IServiceCollection ConfigureAccomodationModule
        (this IServiceCollection services, IConfiguration configuration)

        {
            string connectionString = configuration["DatabaseConfig:ConnectionString"];
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies([Application.AssemblyReference.Assembly]));

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

            services.AddDbContext<AccommodationDbContext>(options =>
                options.UseSqlServer(connectionString, x => x.MigrationsHistoryTable("__MigrationHistory", "accomodation")), ServiceLifetime.Scoped);
            services.AddScoped<IHostRepository, HostRepository>();
            services.AddScoped<IGuestRepository, GuestRepository>();
            services.AddScoped<IAccommodationRepository, AccommodationRepository>();
            services.AddScoped<IAdditionalServiceRepository, AdditionalServiceRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IAvailabilityPeriodRepository, AvailabilityPeriodRepository>();
            services.AddScoped<IReservationRequestRepository, ReservationRequestRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }



}

