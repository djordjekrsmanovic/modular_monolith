using Booking.Accomodation.Domain;
using Booking.Accomodation.Domain.Errors;
using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Reservations.CancelReservationRequest
{
    internal class CancelReservationRequestCommandHandler : ICommandHandler<CancelReservationRequestCommand>
    {
        private readonly IReservationRequestRepository _reservationRequestRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CancelReservationRequestCommandHandler(IReservationRequestRepository reservationRequestRepository, IUnitOfWork unitOfWork)
        {
            _reservationRequestRepository = reservationRequestRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CancelReservationRequestCommand request, CancellationToken cancellationToken)
        {
            ReservationRequest reservationRequest = await _reservationRequestRepository.GetAsync(request.Id);

            if (reservationRequest is null)
            {
                return Result.Failure(ReservationRequestErrors.ReservationRequestNotExist);
            }

            var response = reservationRequest.Cancel();
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return response;
        }
    }
}
