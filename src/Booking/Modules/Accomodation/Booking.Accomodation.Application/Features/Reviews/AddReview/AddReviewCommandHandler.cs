using Booking.Accomodation.Domain;
using Booking.Accomodation.Domain.Errors;
using Booking.Accomodation.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Reviews.AddReview
{
    internal class AddReviewCommandHandler : ICommandHandler<AddReviewCommand>
    {

        private readonly IReviewRepository _reviewRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IReservationRepository _reservationRepository;

        private readonly IGuestRepository _guestRepository;

        public AddReviewCommandHandler(IReviewRepository reviewRepository, IUnitOfWork unitOfWork, IReservationRepository reservationRepository, IGuestRepository guestRepository)
        {
            _reviewRepository = reviewRepository;
            _unitOfWork = unitOfWork;
            _reservationRepository = reservationRepository;
            _guestRepository = guestRepository;
        }

        public async Task<Result> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var existingReview = await _reviewRepository.GetReservationReviewAsync(request.ReservationId);

            if (existingReview is not null)
            {
                return Result.Failure(ReviewErrors.ReservationReviewAlreadyExist);
            }

            var guest = await _guestRepository.GetAsync(request.GuestId);

            if (guest is null)
            {
                return Result.Failure(ReviewErrors.GuestDoesNotExist);
            }

            Reservation reservation = await _reservationRepository.GetAsync(request.ReservationId);

            Review review = Review.Create(request.ReservationId, request.GuestId, reservation.AccomodationId, request.Comment, request.Rating).Value;

            await _reviewRepository.Add(review);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
