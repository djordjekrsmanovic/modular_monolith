﻿using Booking.API.Abstractions;
using Booking.UserAccess.Infrastructure.Authentication;
using Microsoft.Extensions.Options;

namespace Booking.API.Options
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        private const string SectionName = "Jwt";
        private readonly IConfiguration _configuration;

        public JwtOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JwtOptions options)
        {
            _configuration.GetSection(SectionName).Bind(options);
        }
    }
}
