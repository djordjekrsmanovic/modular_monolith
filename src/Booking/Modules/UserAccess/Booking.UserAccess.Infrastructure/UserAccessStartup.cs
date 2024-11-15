﻿using Booking.BuildingBlocks.Application.Emails;
using Booking.BuildingBlocks.Application.EventBus;
using Booking.BuildingBlocks.Infrastructure.Emails;
using Booking.BuildingBlocks.Infrastructure.EventBus;
using Booking.UserAccess.Application.Abstractions;
using Booking.UserAccess.Application.Abstractions.Email;
using Booking.UserAccess.Application.Implementations;
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
            string connectionString = LoadConnectionString();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies([Application.AssemblyReference.Assembly]));

            SetUpServices(services);
            SetUpDatabase(services, connectionString);
            SetUpAuthentication(services);

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
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IUserAccessEmailSender, UserAccessEmailSender>();
            services.AddScoped<ICryptograpyProvider, CryptograpyProvider>();
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
                options.UseNpgsql(connectionString, x => x.MigrationsHistoryTable("__MigrationHistory", "user_access"))
            );
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRegistrationRequestRepository, RegistrationRequestRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }


    }
}
