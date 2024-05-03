using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Accomodation.Domain.Events
{
    public record ReservationCreatedDomainEvent(Guid ReservationId, Money Price) : DomainEvent
    {
    }
}
