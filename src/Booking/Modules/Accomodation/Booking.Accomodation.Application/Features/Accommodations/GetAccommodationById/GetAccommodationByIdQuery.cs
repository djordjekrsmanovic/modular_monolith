using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Accommodations.GetAccommodationById
{
    public record GetAccommodationByIdQuery(Guid Id) : IQuery<GetAccommodationByIdResponse>
    {
    }
}
