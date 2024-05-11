using Booking.Accomodation.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Reviews.GetAccommodationReviews
{
    internal class GetAccommodationReviewsQueryHandler : IQueryHandler<GetAccommodationReviewsQuery, List<ReviewResponse>>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetAccommodationReviewsQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Result<List<ReviewResponse>>> Handle(GetAccommodationReviewsQuery request, CancellationToken cancellationToken)
        {
            List<Review> reviews = await _reviewRepository.GetAccommodationReviews(request.accommodationId);

            return reviews.Select(review =>
            {
                return new ReviewResponse(GuestId: review.GuestId,
                    CreatedAt: review.CreatedAt,
                    Rating: review.Rating,
                    AccommodationId: review.AccommodationId,
                    Comment: review.Comment
               );
            }).ToList();
        }
    }
}
