using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Domain.Events
{
    public sealed record ReviewCreatedDomainEvent(Guid AccommodationId) : DomainEvent
    {
    }
}
