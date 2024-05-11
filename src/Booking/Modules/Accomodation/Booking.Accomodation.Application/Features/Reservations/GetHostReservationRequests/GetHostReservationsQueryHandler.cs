using Booking.Accomodation.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Reservations.GetHostReservationRequests
{
    internal class GetHostReservationsQueryHandler : IQueryHandler<GetHostReservationRequestsQuery, List<ReservationRequestResponse>>
    {
        private readonly IReservationRequestRepository _reservationRequestRepository;

        private readonly IAccommodationRepository _accommodationRepository;

        public GetHostReservationsQueryHandler(IReservationRequestRepository reservationRequestRepository, IAccommodationRepository accommodationRepository)
        {
            _reservationRequestRepository = reservationRequestRepository;
            _accommodationRepository = accommodationRepository;
        }

        public async Task<Result<List<ReservationRequestResponse>>> Handle(GetHostReservationRequestsQuery request, CancellationToken cancellationToken)
        {
            List<ReservationRequest> response = await _reservationRequestRepository.GetHostReservationRequests(request.HostId);

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
