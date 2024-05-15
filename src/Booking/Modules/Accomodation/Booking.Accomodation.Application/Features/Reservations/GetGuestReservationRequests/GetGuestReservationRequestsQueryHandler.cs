using Booking.AccommodationNS.Application.Features.Reservations.GetHostReservationRequests;
using Booking.AccommodationNS.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.AccommodationNS.Application.Features.Reservations.GetGuestReservationRequests
{
    internal class GetGuestReservationRequestsQueryHandler : IQueryHandler<GetGuestReservationRequestsQuery, List<ReservationRequestResponse>>
    {

        private readonly IReservationRequestRepository _reservationRequestRepository;

        private readonly IAccommodationRepository _accommodationRepository;

        public GetGuestReservationRequestsQueryHandler(IReservationRequestRepository reservationRequestRepository, IAccommodationRepository accommodationRepository)
        {
            _reservationRequestRepository = reservationRequestRepository;
            _accommodationRepository = accommodationRepository;
        }

        public async Task<Result<List<ReservationRequestResponse>>> Handle(GetGuestReservationRequestsQuery request, CancellationToken cancellationToken)
        {
            List<ReservationRequest> response = await _reservationRequestRepository.GetGuestReservationRequests(request.GuestId);

            List<ReservationRequestResponse> result = new List<ReservationRequestResponse>();

            foreach (var item in response)
            {
                var accommodation = await _accommodationRepository.GetAsync(item.AccomodationId);
                result.Add(new ReservationRequestResponse(accommodation.Name, item));
            }

            return result;
        }
    }
}
