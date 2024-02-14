using Booking.BuildingBlocks.Application.Emails;
using Booking.BuildingBlocks.Application.EventBus;
using Booking.BuildingBlocks.Infrastructure.Emails;
using Booking.BuildingBlocks.Infrastructure.EventBus;
using Booking.UserAccess.Application.Abstractions;
using Booking.UserAccess.Domain;
using Booking.UserAccess.Domain.Repositories;
using Booking.UserAccess.Infrastructure.Authentication;
using Booking.UserAccess.Infrastructure.Database;
using Booking.UserAccess.Infrastructure.Database.Repositories;
using Booking.UserAccess.Infrastructure.Emails.RegistrationConfirmationEmail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.UserAccess.Infrastructure
{
    public static class UserAccessStartup
    {
        public static IServiceCollection ConfigureUserAccessModule(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = "Server=NHL2131W;Database=Booking;Trusted_Connection=True;TrustServerCertificate=True;";
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies([Application.AssemblyReference.Assembly]));

            SetUpServices(services);
            SetUpDatabase(services, connectionString);
            SetUpAuthentication(services);

            return services;
        }

        private static void SetUpServices(IServiceCollection services)
        {
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IUserAccessEmailSender, UserAccessEmailSender>();
            services.AddTransient<IEventBus, EventBus>();
        }



        private static void SetUpAuthentication(IServiceCollection services)
        {
            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
        }

        private static void SetUpDatabase(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<UserAccessDbContext>(options =>
                options.UseSqlServer(connectionString, x => x.MigrationsHistoryTable("__MigrationHistory", "user_access"))
            );
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRegistrationRequestRepository, RegistrationRequestRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }


    }
}
