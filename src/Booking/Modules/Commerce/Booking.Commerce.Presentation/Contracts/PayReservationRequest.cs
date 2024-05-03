using Booking.Commerce.Domain.Enums;

namespace Booking.Commerce.Presentation.Contracts
{
    public record PayReservationRequest(Guid ReservationId, PaymentMethod Method)
    {
    }
}
