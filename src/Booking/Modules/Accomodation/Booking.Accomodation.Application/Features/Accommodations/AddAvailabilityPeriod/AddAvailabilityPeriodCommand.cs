using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.AccommodationNS.Application.Features.Accommodations.AddAvailabilityPeriod
{
    public sealed record AddAvailabilityPeriodCommand(Guid AccommodationId, DateTime Start, DateTime End, Double PricePerGuest) : ICommand<AvailabilityPeriodResponse>
    {
    }
}
