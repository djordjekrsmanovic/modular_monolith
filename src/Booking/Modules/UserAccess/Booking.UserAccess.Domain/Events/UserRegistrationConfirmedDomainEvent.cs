using Booking.BuildingBlocks.Domain;

namespace Booking.UserAccess.Domain.Events
{
    public sealed record UserRegistrationConfirmedDomainEvent(Guid UserRegistrationId) : DomainEvent()
    {

    }

}
