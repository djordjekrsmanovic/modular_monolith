using Booking.BuildingBlocks.Application.CQRS;
using Booking.UserAccess.Domain.Enums;

namespace Booking.UserAccess.Application.Features.Registration.SubmitRegistrationRequest
{
    public sealed record RegistrationCommand(string Email,
        string Password,
        string FirstName,
        string LastName,
        RegistrationType Type) : ICommand<Guid>;
}
