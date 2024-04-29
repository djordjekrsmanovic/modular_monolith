using Booking.Accomodation.Domain;
using Booking.Accomodation.Domain.Errors;
using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Accomodation.Application.Features.Reservations.CreateReservationRequest
{
    internal class CreateReservationRequestCommandHandler : ICommandHandler<CreateReservationRequestCommand>
    {
        private readonly IAccommodationRepository _accommodationRepository;

        private readonly IReservationRequestRepository _reservationRequestRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CreateReservationRequestCommandHandler(IAccommodationRepository accommodationRepository, IReservationRequestRepository reservationRequestRepository, IUnitOfWork unitOfWork)
        {
            _accommodationRepository = accommodationRepository;
            _reservationRequestRepository = reservationRequestRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateReservationRequestCommand request, CancellationToken cancellationToken)
        {
            Accommodation accommodation = await _accommodationRepository.GetAsync(request.AccommodationId);

            if (accommodation.IsAvailableForBooking(request.Start, request.End) && accommodation.Capacity.CheckAccommodationCapacity(request.GuestNumber) && accommodation.ReservationApprovalRequired)
            {

                DateTimeSlot slot = DateTimeSlot.Create(request.Start, request.End).Value;
                var reservationRequestResponse = ReservationRequest.Create(slot, request.GuestNumber, request.Messsage, request.GuestId, request.AccommodationId);
                await _reservationRequestRepository.Add(reservationRequestResponse.Value);
                await _unitOfWork.SaveChangesAsync();
                return Result.Success();
            }

            return Result.Failure(ReservationRequestErrors.UnableToCreateReservationRequest);
        }
    }
}
