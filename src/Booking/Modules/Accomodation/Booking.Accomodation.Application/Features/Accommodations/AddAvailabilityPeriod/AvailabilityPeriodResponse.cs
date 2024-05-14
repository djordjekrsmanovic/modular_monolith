using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.AccommodationNS.Application.Features.Accommodations.AddAvailabilityPeriod
{
    public record AvailabilityPeriodResponse(Guid Id, Guid AccommodationId, DateTimeSlot Slot, string Price)
    {
    }
}
