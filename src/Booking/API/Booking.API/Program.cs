using Booking.API.Startup;
using Booking.App.Options;
using Booking.BuildingBlocks.Infrastructure.Extensions;
using Booking.UserAccess.Infrastructure.Authentication;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




// Configure jwt authentication
builder.Services.ConfigureOptions<Booking.API.Options.JwtOptionsSetup>();
builder.Services.ConfigureOptions<Booking.API.Options.JwtBearerOptionsSetup>();



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.AddAuthorization();

builder.Services.RegisterModules(builder.Configuration);

builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
builder.Services.ConfigureOptions<MassTransitHostOptionsSetup>()
    .AddMassTransit(x =>
{
    x.AddConsumersFromAssemblies([
        Booking.Booking.Infrastructure.AssemblyReference.Assembly,
        Booking.Commerce.Infrastructure.AssemblyReference.Assembly,
        Booking.UserAccess.Infrastructure.AssemblyReference.Assembly,
    ]);
    x.SetKebabCaseEndpointNameFormatter();
    x.SetKebabCaseEndpointNameFormatter();
    x.UsingInMemory((context, configurator) => configurator.ConfigureEndpoints(context));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();


