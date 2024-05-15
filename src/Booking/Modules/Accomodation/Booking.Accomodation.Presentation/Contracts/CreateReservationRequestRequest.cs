namespace Booking.AccommodationNS.Presentation.Contracts
{
    public record CreateReservationRequestRequest(Guid AccommodationId, Guid GuestId, int GuestNumber, string Message, DateTime Start, DateTime End)
    {
    }
}
