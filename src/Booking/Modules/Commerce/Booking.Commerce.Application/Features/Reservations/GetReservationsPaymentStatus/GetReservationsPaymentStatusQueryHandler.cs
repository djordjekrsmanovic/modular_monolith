using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Application.Features.Reservations.GetReservationsPaymentStatus
{
    internal class GetReservationsPaymentStatusQueryHandler : IQueryHandler<GetReservationPaymentStatusQuery, ReservationPaymentStatusResponse>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationsPaymentStatusQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Result<ReservationPaymentStatusResponse>> Handle(GetReservationPaymentStatusQuery request, CancellationToken cancellationToken)
        {

            Reservation reservation = await _reservationRepository.Get(request.ReservationId);

            if (reservation.Payments.Count == 0)
            {
                return Result.Success(new ReservationPaymentStatusResponse("NotExist"));
            }

            var status = reservation.Payments.OrderByDescending(x => x.ExecutonTime).FirstOrDefault().Status.ToString();
            return Result.Success(new ReservationPaymentStatusResponse(status));
        }
    }
}
