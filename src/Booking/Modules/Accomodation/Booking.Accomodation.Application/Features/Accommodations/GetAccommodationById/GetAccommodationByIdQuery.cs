using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.AccommodationNS.Application.Features.Accommodations.GetAccommodationById
{
    public sealed record GetAccommodationByIdQuery(Guid Id) : IQuery<GetAccommodationByIdResponse>
    {
    }
}
