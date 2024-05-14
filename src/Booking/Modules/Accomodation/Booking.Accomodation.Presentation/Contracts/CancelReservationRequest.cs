namespace Booking.AccommodationNS.Presentation.Contracts
{
    public record CancelReservationRequest(Guid AccommodationId, Guid ReservationId)
    {
    }
}
