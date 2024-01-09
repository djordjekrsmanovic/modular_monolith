
using Booking.BuildingBlocks.Domain;

namespace Booking.UserAccess.Domain.Events
{
    public record RegistrationRequestSubmittedDomainEvent(string Email,string ConfirmationCode):DomainEvent()
    {
    }
}
