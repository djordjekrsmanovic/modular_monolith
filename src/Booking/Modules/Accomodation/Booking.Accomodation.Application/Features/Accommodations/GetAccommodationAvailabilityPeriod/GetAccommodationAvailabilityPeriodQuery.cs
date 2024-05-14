using Booking.Accomodation.Application.Features.Accommodations.AddAvailabilityPeriod;
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Accommodations.GetAccommodationAvailabilityPeriod
{
    public sealed record GetAccommodationAvailabilityPeriodQuery(Guid AccommodationId) : IQuery<List<AvailabilityPeriodResponse>>
    {
    }
}
