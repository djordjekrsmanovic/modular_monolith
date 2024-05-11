using Booking.Accomodation.Domain;
using Booking.Accomodation.Domain.Events;
using Booking.Accomodation.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Reviews.AddReview
{
    internal class ReviewCreatedDomainEventHandler : IDomainEventHandler<ReviewCreatedDomainEvent>
    {

        private readonly IAccommodationRepository _accommodationRepository;

        private readonly IReviewRepository _reviewRepository;

        private readonly IUnitOfWork _unitOfWork;

        public ReviewCreatedDomainEventHandler(IAccommodationRepository accommodationRepository, IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
        {
            _accommodationRepository = accommodationRepository;
            _reviewRepository = reviewRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ReviewCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            Accommodation accommodation = _accommodationRepository.GetWithoutRelations(notification.AccommodationId);

            List<Review> reviews = await _reviewRepository.GetAccommodationReviews(accommodation.Id);

            accommodation.RecalculateRating(reviews);

            await _unitOfWork.SaveChangesAsync();

        }
    }
}
