using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Domain.Entities;

namespace Booking.Commerce.Domain.Events
{
    public sealed record ReservationPaymentConfirmedDomainEvent(ReservationPayment payment) : DomainEvent
    {
    }
}
