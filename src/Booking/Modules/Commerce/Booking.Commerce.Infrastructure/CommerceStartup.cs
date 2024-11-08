using Booking.BuildingBlocks.Application.EventBus;
using Booking.BuildingBlocks.Infrastructure.EventBus;
using Booking.Commerce.Domain;
using Booking.Commerce.Domain.Repositories;
using Booking.Commerce.Infrastructure.Database;
using Booking.Commerce.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Commerce.Infrastructure
{
    public static class CommerceStartup
    {
        public static IServiceCollection ConfigureCommerceModule(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = LoadConnectionString();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies([Application.AssemblyReference.Assembly]));

            SetUpServices(services);
            SetUpDatabase(services, connectionString);

            return services;
        }

        private static string LoadConnectionString()
        {
            string databaseName = Environment.GetEnvironmentVariable("POSTGRES_DB");
            string databaseUser = Environment.GetEnvironmentVariable("POSTGRES_USER");
            string databasePassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
            string databaseHost = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost";
            string databasePort = Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? "5432"; // default port is 5432

            // Construct the connection string
            return $"Host={databaseHost};Port={databasePort};Database={databaseName};Username={databaseUser};Password={databasePassword};";
        }


        private static void SetUpServices(IServiceCollection services)
        {

            services.AddTransient<IEventBus, EventBus>();
        }


        private static void SetUpDatabase(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CommerceDbContext>(options =>
            options.UseNpgsql(connectionString, x => x.MigrationsHistoryTable("__MigrationHistory", "commerce")),
            ServiceLifetime.Scoped
        );


            services.AddScoped<ISubscriberRepository, SubscriberRepository>();
            services.AddScoped<IPayerRepository, PayerRepository>();
            services.AddScoped<ISubscriptionPlanRepository, SubscriptionPlanRepository>();
            services.AddScoped<ISubscriberRepository, SubscriberRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IReservationPaymentRepository, ReservationPaymentRepository>();
            services.AddScoped<IReservationInvoiceRepository, ReservationInvoiceRepository>();
            services.AddScoped<ISubscriptionInvoiceRepository, SubscriptionInvoiceRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
