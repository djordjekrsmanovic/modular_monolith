using Booking.Accomodation.Application.Features.Reservations.GetHostReservations;
using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Reservations.GetGuestReservations
{
    internal class GetGuestReservationsQueryHandler : IQueryHandler<GetGuestReservationsQuery, List<ReservationResponse>>
    {
        private readonly IReservationRepository _reservationRepository;

        private readonly IAccommodationRepository _accommodationRepository;

        private readonly IReviewRepository _reviewRepository;

        public GetGuestReservationsQueryHandler(IReservationRepository reservationRepository, IAccommodationRepository accommodationRepository, IReviewRepository reviewRepository)
        {
            _reservationRepository = reservationRepository;
            _accommodationRepository = accommodationRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task<Result<List<ReservationResponse>>> Handle(GetGuestReservationsQuery request, CancellationToken cancellationToken)
        {

            List<Reservation> reservations = await _reservationRepository.GetGuestReservations(request.GuestId);

            List<ReservationResponse> responses = new List<ReservationResponse>();

            foreach (var r in reservations)
            {
                Accommodation accommodation = _accommodationRepository.GetWithoutRelations(r.AccomodationId);
                Review review = await _reviewRepository.GetReservationReviewAsync(r.Id);
                bool reviewExist = review is not null ? true : false;
                responses.Add(new ReservationResponse(
                        AccommodationId: accommodation.Id,
                        Accommodation: accommodation.Name,
                        Address: accommodation.Address.ConvertToString(),
                        Price: r.TotalPrice.ConvertToString(),
                        ReservationId: r.Id,
                        Slot: r.Slot,
                        ReviewExist: reviewExist
                    ));
            }
            return responses;
        }
    }
}
