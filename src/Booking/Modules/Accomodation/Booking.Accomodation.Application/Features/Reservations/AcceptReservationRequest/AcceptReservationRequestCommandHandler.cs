using Booking.AccommodationNS.Domain;
using Booking.AccommodationNS.Domain.Errors;
using Booking.AccommodationNS.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.AccommodationNS.Application.Features.Reservations.AcceptReservationRequest
{
    internal sealed class AcceptReservationRequestCommandHandler : ICommandHandler<AcceptReservationRequestCommand>
    {
        private readonly IReservationRequestRepository _reservationRequestRepository;

        private readonly IUnitOfWork _unitOfWork;

        public AcceptReservationRequestCommandHandler(IReservationRequestRepository reservationRequestRepository, IUnitOfWork unitOfWork)
        {
            _reservationRequestRepository = reservationRequestRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AcceptReservationRequestCommand request, CancellationToken cancellationToken)
        {
            ReservationRequest reservationRequest = await _reservationRequestRepository.GetAsync(request.ReservationRequestId);

            if (reservationRequest is null)
            {
                return Result.Failure(ReservationRequestErrors.ReservationRequestNotExist);
            }

            var response = reservationRequest.Accept();
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return response;
        }
    }
}
