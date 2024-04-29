namespace Booking.Accomodation.Presentation.Contracts
{
    public record CalculateReservationPriceRequest(Guid AccommodationId, DateTime Start, DateTime End, int GuestNumber)
    {
    }
}
