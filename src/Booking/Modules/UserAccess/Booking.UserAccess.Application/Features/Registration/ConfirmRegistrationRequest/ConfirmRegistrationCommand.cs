using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.UserAccess.Application.Features.Registration.ConfirmRegistrationRequest
{
    public sealed record ConfirmRegistrationCommand(string ConfirmationCode):ICommand
    {
    }
}
