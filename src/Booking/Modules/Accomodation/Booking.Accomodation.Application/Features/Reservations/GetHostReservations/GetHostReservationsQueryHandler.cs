using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Reservations.GetHostReservations
{
    internal class GetHostReservationsQueryHandler : IQueryHandler<GetHostReservationsQuery, List<ReservationResponse>>
    {

        private readonly IAccommodationRepository _accommodationRepository;

        public GetHostReservationsQueryHandler(IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
        }

        public async Task<Result<List<ReservationResponse>>> Handle(GetHostReservationsQuery request, CancellationToken cancellationToken)
        {
            List<Accommodation> accommodations = await _accommodationRepository.GetHostAccommodations(request.HostId);

            List<ReservationResponse> responses = new List<ReservationResponse>();

            foreach (Accommodation accommodation in accommodations)
            {
                accommodation.Reservations.ForEach(r =>
                {
                    responses.Add(new ReservationResponse(
                        AccommodationId: accommodation.Id,
                        Accommodation: accommodation.Name,
                        Address: accommodation.Address.ConvertToString(),
                        Price: r.TotalPrice.ConvertToString(),
                        ReservationId: r.Id,
                        Slot: r.Slot
                    ));
                });
            }

            return responses;
        }
    }
}
