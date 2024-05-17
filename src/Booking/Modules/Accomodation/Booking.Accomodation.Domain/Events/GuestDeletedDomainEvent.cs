using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Domain.Events
{
    public sealed record GuestDeletedDomainEvent(Guid GuestId) : DomainEvent
    {
    }
}
