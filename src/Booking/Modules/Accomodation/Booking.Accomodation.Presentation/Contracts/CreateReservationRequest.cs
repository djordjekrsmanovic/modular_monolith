namespace Booking.AccommodationNS.Presentation.Contracts
{
    public record CreateReservationRequest(Guid AccommodationId, Guid GuestId, Double Price, int GuestNumber, DateTime Start, DateTime End)
    {
    }
}
