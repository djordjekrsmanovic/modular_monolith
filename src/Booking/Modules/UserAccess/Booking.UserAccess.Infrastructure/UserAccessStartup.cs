using Booking.UserAccess.Application.Abstractions;
using Booking.UserAccess.Application.Features.Registration.ConfirmRegistrationRequest;
using Booking.UserAccess.Domain;
using Booking.UserAccess.Domain.Repositories;
using Booking.UserAccess.Infrastructure.Authentication;
using Booking.UserAccess.Infrastructure.Database;
using Booking.UserAccess.Infrastructure.Database.Constants;
using Booking.UserAccess.Infrastructure.Database.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.UserAccess.Infrastructure
{
    public static class UserAccessStartup
    {
        public static IServiceCollection ConfigureUserAccessModule(this IServiceCollection services,IConfiguration configuration)
        {
            string connectionString = configuration["DatabaseConfig:ConnectionString"];
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies([Application.AssemblyReference.Assembly]));
            SetUpDatabase(services, connectionString);
            SetUpAuthentication(services);
            return services;
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

        private static void SetUpDatabase(IServiceCollection services,string connectionString)
        {
            services.AddDbContext<UserAccessDbContext>(options =>
            options.UseSqlServer(connectionString,
            x => x.MigrationsHistoryTable("__MigrationHistory", "user_access")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRegistrationRequestRepository, RegistrationRequestRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        
    }
}
