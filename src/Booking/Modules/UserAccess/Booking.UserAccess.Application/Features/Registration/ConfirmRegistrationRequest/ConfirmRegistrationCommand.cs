

using Booking.BuildingBlocks.Application;

namespace Booking.UserAccess.Application.Features.Registration.ConfirmRegistrationRequest
{
    public sealed record ConfirmRegistrationCommand(string ConfirmationCode):ICommand
    {
    }
}
