namespace Booking.AccommodationNS.Presentation.Contracts
{
    public record DeleteAvailabilityPeriodRequest(Guid AccommodationId, Guid AvailabilityPeriodId)
    {
    }
}
