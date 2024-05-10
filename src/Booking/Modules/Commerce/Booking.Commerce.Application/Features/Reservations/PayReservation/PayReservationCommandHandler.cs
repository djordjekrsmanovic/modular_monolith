using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Domain;
using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Application.Features.Reservations.PayReservation
{
    internal class PayReservationCommandHandler : ICommandHandler<PayReservationCommand>
    {

        private readonly IReservationRepository _reservationRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IReservationPaymentRepository _paymentRepository;

        public PayReservationCommandHandler(IReservationRepository reservationRepository, IUnitOfWork unitOfWork, IReservationPaymentRepository paymentRepository)
        {
            _reservationRepository = reservationRepository;
            _unitOfWork = unitOfWork;
            _paymentRepository = paymentRepository;
        }

        public async Task<Result> Handle(PayReservationCommand request, CancellationToken cancellationToken)
        {
            Reservation reservation = await _reservationRepository.Get(request.ReservationId);

            var response = reservation.Pay(request.Method, request.PayerId);

            if (response.IsSuccess)
            {
                await _paymentRepository.Add(response.Value);

                await _unitOfWork.SaveChangesAsync();
            }

            return response;

        }
    }
}
