using Booking.BuildingBlocks.Application;


namespace Booking.UserAccess.Application.Features.Login
{
    public record LoginCommand(string username, string password) : ICommand<string>
    {
    }
}
