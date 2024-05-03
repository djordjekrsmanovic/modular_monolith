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

        public GetGuestReservationsQueryHandler(IReservationRepository reservationRepository, IAccommodationRepository accommodationRepository)
        {
            _reservationRepository = reservationRepository;
            _accommodationRepository = accommodationRepository;
        }

        public async Task<Result<List<ReservationResponse>>> Handle(GetGuestReservationsQuery request, CancellationToken cancellationToken)
        {

            List<Reservation> reservations = await _reservationRepository.GetGuestReservations(request.GuestId);

            List<ReservationResponse> responses = new List<ReservationResponse>();

            reservations.ForEach(r =>
            {
                Accommodation accommodation = _accommodationRepository.GetWithoutRelations(r.AccomodationId);
                responses.Add(new ReservationResponse(
                        AccommodationId: accommodation.Id,
                        Accommodation: accommodation.Name,
                        Address: accommodation.Address.ConvertToString(),
                        Price: r.TotalPrice.ConvertToString(),
                        ReservationId: r.Id,
                        Slot: r.Slot
                    ));
            });

            return responses;
        }
    }
}
