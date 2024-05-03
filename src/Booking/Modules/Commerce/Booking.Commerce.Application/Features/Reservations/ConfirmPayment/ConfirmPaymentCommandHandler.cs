using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Domain;
using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Application.Features.Reservations.ConfirmPayment
{
    internal class ConfirmPaymentCommandHandler : ICommandHandler<ConfirmPaymentCommand>
    {
        private readonly IReservationRepository _reservationRepository;

        private readonly IUnitOfWork _unitOfWork;

        public ConfirmPaymentCommandHandler(IReservationRepository reservationRepository, IUnitOfWork unitOfWork)
        {
            _reservationRepository = reservationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ConfirmPaymentCommand request, CancellationToken cancellationToken)
        {
            Reservation reservation = await _reservationRepository.Get(request.ReservationId);

            var response = reservation.ConfirmPayment();

            await _unitOfWork.SaveChangesAsync();

            return response;

        }
    }
}
