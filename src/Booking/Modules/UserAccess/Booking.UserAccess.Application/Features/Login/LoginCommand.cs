using Booking.BuildingBlocks.Application.CQRS;


namespace Booking.UserAccess.Application.Features.Login
{
    public sealed record LoginCommand(string username, string password) : ICommand<LoginResponse>
    {
    }
}
