using MassTransit;
using Microsoft.Extensions.Options;

namespace Booking.App.Options
{
    internal sealed class MassTransitHostOptionsSetup : IConfigureOptions<MassTransitHostOptions>
    {
        /// <inheritdoc />
        public void Configure(MassTransitHostOptions options) => options.WaitUntilStarted = true;
    }
}
