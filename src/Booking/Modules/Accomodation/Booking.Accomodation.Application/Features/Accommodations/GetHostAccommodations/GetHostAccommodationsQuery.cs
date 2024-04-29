using Booking.Accomodation.Application.Features.Accommodations.GetAccommodation;
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Accommodations.GetHostAccommodations
{
    public record GetHostAccommodationsQuery(Guid HostId) : IQuery<List<AccommodationResponse>>
    {
    }
}
