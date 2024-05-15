
using Booking.BuildingBlocks.Domain;

namespace Booking.UserAccess.Domain.Events
{
    public sealed record RegistrationRequestSubmittedDomainEvent(string Email, string ConfirmationCode) : DomainEvent()
    {
    }
}
