using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Accommodations.GetAccommodationById
{
    public sealed record GetAccommodationByIdQuery(Guid Id) : IQuery<GetAccommodationByIdResponse>
    {
    }
}
