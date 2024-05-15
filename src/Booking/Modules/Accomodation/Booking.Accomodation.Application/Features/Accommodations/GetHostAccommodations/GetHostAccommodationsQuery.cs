using Booking.AccommodationNS.Application.Features.Accommodations.GetAccommodation;
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.AccommodationNS.Application.Features.Accommodations.GetHostAccommodations
{
    public sealed record GetHostAccommodationsQuery(Guid HostId) : IQuery<List<AccommodationResponse>>
    {
    }
}
