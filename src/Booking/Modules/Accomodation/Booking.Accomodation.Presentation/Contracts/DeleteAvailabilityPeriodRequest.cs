namespace Booking.Accomodation.Presentation.Contracts
{
    public record DeleteAvailabilityPeriodRequest(Guid AccommodationId, Guid AvailabilityPeriodId)
    {
    }
}
