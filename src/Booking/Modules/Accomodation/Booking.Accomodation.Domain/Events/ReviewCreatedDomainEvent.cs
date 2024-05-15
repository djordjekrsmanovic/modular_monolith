using Booking.BuildingBlocks.Domain;

namespace Booking.AccommodationNS.Domain.Events
{
    public sealed record ReviewCreatedDomainEvent(Guid AccommodationId) : DomainEvent
    {
    }
}
