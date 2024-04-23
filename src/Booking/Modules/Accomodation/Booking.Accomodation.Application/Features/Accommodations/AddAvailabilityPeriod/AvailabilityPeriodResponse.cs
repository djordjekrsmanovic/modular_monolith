using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Accomodation.Application.Features.Accommodations.AddAvailabilityPeriod
{
    public record AvailabilityPeriodResponse(Guid Id, Guid AccommodationId, DateTimeSlot Slot, string Price)
    {
    }
}
