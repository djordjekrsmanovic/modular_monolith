using Booking.Commerce.Domain.Enums;

namespace Booking.Commerce.Presentation.Contracts
{
    public sealed record PayReservationRequest(Guid ReservationId, PaymentMethod Method, Guid PayerId)
    {
    }
}
