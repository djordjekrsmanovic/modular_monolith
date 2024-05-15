using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.AccommodationNS.Application.Features.Accommodations.DeleteAvailabilityPeriod
{
    public sealed record DeleteAvailabilityPeriodCommand(Guid AccommodationId, Guid AvailabilityPeriodId) : ICommand
    {
    }
}
