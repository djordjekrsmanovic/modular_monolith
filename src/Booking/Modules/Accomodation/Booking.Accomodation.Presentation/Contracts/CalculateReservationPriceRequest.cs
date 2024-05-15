namespace Booking.AccommodationNS.Presentation.Contracts
{
    public record CalculateReservationPriceRequest(Guid AccommodationId, DateTime Start, DateTime End, int GuestNumber)
    {
    }
}
