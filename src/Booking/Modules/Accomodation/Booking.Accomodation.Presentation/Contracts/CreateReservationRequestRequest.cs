namespace Booking.Accomodation.Presentation.Contracts
{
    public record CreateReservationRequestRequest(Guid AccommodationId, Guid GuestId, int GuestNumber, string Message, DateTime Start, DateTime End)
    {
    }
}
