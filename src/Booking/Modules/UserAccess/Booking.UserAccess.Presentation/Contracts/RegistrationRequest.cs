using Booking.UserAccess.Domain.Enums;

namespace Booking.UserAccess.Presentation.Contracts
{
    public record RegistrationRequest(
        string Email,
        string Password,
        string FirstName,
        string LastName,
        RegistrationType Type
     );
}
