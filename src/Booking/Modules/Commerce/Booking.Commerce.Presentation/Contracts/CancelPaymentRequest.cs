namespace Booking.Commerce.Presentation.Contracts
{
    public sealed record CancelPaymentRequest(Guid ReservationId)
    {
    }
}
