using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Reservations.GetHostReservations
{
    internal class GetHostReservationsQueryHandler : IQueryHandler<GetHostReservationsQuery, List<ReservationResponse>>
    {

        private readonly IAccommodationRepository _accommodationRepository;

        private readonly IReviewRepository _reviewRepository;

        public GetHostReservationsQueryHandler(IAccommodationRepository accommodationRepository, IReviewRepository reviewRepository)
        {
            _accommodationRepository = accommodationRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task<Result<List<ReservationResponse>>> Handle(GetHostReservationsQuery request, CancellationToken cancellationToken)
        {
            List<Accommodation> accommodations = await _accommodationRepository.GetHostAccommodations(request.HostId);

            List<ReservationResponse> responses = new List<ReservationResponse>();

            foreach (Accommodation accommodation in accommodations)
            {
                foreach (Reservation r in accommodation.Reservations)
                {
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
            }

            return responses;
        }
    }
}
