using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Hosts.DeleteHost
{
    public sealed record DeleteHostCommand(Guid HostId) : ICommand
    {
    }
}
