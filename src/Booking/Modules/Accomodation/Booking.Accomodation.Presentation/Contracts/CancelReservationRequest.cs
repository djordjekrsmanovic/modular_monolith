namespace Booking.Accomodation.Presentation.Contracts
{
    public record CancelReservationRequest(Guid AccommodationId, Guid ReservationId)
    {
    }
}
