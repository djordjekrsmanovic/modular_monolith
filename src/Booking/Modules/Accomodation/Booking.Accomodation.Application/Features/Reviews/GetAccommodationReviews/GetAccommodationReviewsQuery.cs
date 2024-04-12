using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Reviews.GetAccommodationReviews
{
    public record GetAccommodationReviewsQuery(Guid accommodationId) : IQuery<List<ReviewResponse>>
    {
    }
}
