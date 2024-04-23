using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Accommodations.AddAvailabilityPeriod
{
    public record AddAvailabilityPeriodCommand(Guid AccommodationId, DateTime Start, DateTime End, Double PricePerGuest) : ICommand<AvailabilityPeriodResponse>
    {
    }
}
