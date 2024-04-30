using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Reservations.GetGuestReservationRequests
{
    internal class GetGuestReservationRequestsQueryHandler : IQueryHandler<GetGuestReservationRequestsQuery, List<ReservationRequest>>
    {

        private readonly IReservationRequestRepository _reservationRequestRepository;

        public GetGuestReservationRequestsQueryHandler(IReservationRequestRepository reservationRequestRepository)
        {
            _reservationRequestRepository = reservationRequestRepository;
        }

        public async Task<Result<List<ReservationRequest>>> Handle(GetGuestReservationRequestsQuery request, CancellationToken cancellationToken)
        {
            return await _reservationRequestRepository.GetGuestReservationRequests(request.GuestId);
        }
    }
}
