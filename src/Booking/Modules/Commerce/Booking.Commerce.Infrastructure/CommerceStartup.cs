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
            string connectionString = "Server=NHL2131W;Database=Booking;Trusted_Connection=True;TrustServerCertificate=True;";
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies([Application.AssemblyReference.Assembly]));

            SetUpServices(services);
            SetUpDatabase(services, connectionString);
            //SetUpAuthentication(services);

            return services;
        }

        private static void SetUpServices(IServiceCollection services)
        {

            services.AddTransient<IEventBus, EventBus>();
        }


        private static void SetUpDatabase(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CommerceDbContext>(options =>
            options.UseSqlServer(connectionString, x => x.MigrationsHistoryTable("__MigrationHistory", "commerce")),
            ServiceLifetime.Scoped
        );


            services.AddScoped<ISubscriberRepository, SubscriberRepository>();
            services.AddScoped<IPayerRepository, PayerRepository>();
            services.AddScoped<ISubscriptionPlanRepository, SubscriptionPlanRepository>();
            services.AddScoped<ISubscriberRepository, SubscriberRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
