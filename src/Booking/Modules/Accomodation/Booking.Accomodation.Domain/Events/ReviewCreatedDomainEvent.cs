using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Domain.Events
{
    public record ReviewCreatedDomainEvent(Guid AccommodationId) : DomainEvent
    {
    }
}
