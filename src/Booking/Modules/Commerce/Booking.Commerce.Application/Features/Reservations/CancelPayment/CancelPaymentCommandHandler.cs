using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Domain;
using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Application.Features.Reservations.CancelPayment
{
    internal class CancelPaymentCommandHandler : ICommandHandler<CancelPaymentCommand>
    {
        private readonly IReservationRepository _reservationRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CancelPaymentCommandHandler(IReservationRepository reservationRepository, IUnitOfWork unitOfWork)
        {
            _reservationRepository = reservationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CancelPaymentCommand request, CancellationToken cancellationToken)
        {
            Reservation reservation = await _reservationRepository.Get(request.ReservationId);

            var response = reservation.CancelPayment();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}
