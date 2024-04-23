using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Accommodations.DeleteAvailabilityPeriod
{
    public record DeleteAvailabilityPeriodCommand(Guid AccommodationId, Guid AvailabilityPeriodId) : ICommand
    {
    }
}
