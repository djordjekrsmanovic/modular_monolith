using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.AccommodationNS.Domain.Events
{
    public sealed record ReservationCreatedDomainEvent(Guid ReservationId, Money Price) : DomainEvent
    {
    }
}
