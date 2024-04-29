using Booking.Accomodation.Domain;
using Booking.Accomodation.Domain.Errors;
using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Reservations.AcceptReservationRequest
{
    internal class AcceptReservationRequestCommandHandler : ICommandHandler<AcceptReservationRequestCommand>
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
