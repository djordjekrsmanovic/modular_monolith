using Booking.AccommodationNS.Domain;
using Booking.AccommodationNS.Domain.Errors;
using Booking.AccommodationNS.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.AccommodationNS.Application.Features.Reservations.CancelReservationRequest
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
