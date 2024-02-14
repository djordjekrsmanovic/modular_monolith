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
            string connectionString = configuration["DatabaseConfig:ConnectionString"];
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies([Application.AssemblyReference.Assembly]));

            //SetUpServices(services);
            SetUpDatabase(services, connectionString);
            //SetUpAuthentication(services);

            return services;
        }

        /* private static void SetUpServices(IServiceCollection services)
         {
             services.AddScoped<IEmailSender, EmailSender>();
             services.AddScoped<IUserAccessEmailSender, UserAccessEmailSender>();
             services.AddScoped<IEventBus, EventBus>();
         }*/


        private static void SetUpDatabase(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CommerceDbContext>(options =>
                options.UseSqlServer(connectionString, x => x.MigrationsHistoryTable("__MigrationHistory", "commerce"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISubscriberRepository, SubscriberRepository>();
            services.AddScoped<IPayerRepository, PayerRepository>();
        }
    }
}
