using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Accommodations.DeleteAvailabilityPeriod
{
    public sealed record DeleteAvailabilityPeriodCommand(Guid AccommodationId, Guid AvailabilityPeriodId) : ICommand
    {
    }
}
