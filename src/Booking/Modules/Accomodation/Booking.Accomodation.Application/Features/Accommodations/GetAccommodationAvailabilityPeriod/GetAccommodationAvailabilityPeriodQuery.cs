using Booking.AccommodationNS.Application.Features.Accommodations.AddAvailabilityPeriod;
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.AccommodationNS.Application.Features.Accommodations.GetAccommodationAvailabilityPeriod
{
    public sealed record GetAccommodationAvailabilityPeriodQuery(Guid AccommodationId) : IQuery<List<AvailabilityPeriodResponse>>
    {
    }
}
