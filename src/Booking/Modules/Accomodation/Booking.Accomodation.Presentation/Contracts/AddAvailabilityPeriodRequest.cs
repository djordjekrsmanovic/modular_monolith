namespace Booking.AccommodationNS.Presentation.Contracts
{
    public record AddAvailabilityPeriodRequest(Guid AccommodationId, DateTime Start, DateTime End, Double PricePerGuest)
    {
    }
}
