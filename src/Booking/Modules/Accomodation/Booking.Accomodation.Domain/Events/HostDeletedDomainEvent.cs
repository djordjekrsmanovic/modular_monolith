using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Domain.Events
{
    public sealed record HostDeletedDomainEvent(Guid HostId) : DomainEvent
    {
    }
}
