using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Domain.Entities;

namespace Booking.Commerce.Domain.Events
{
    public record ReservationPaymentConfirmed(ReservationPayment payment) : DomainEvent
    {
    }
}
