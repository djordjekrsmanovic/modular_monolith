using Booking.Accomodation.Domain;
using Booking.Accomodation.Domain.Errors;
using Booking.Accomodation.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Accomodation.Application.Features.Reservations.CreateReservation
{
    internal class CreateReservationCommandHandler : ICommandHandler<CreateReservationCommand>
    {

        private readonly IAccommodationRepository _accommodationRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IReservationRepository _reservationRepository;

        public CreateReservationCommandHandler(IAccommodationRepository accommodationRepository, IUnitOfWork unitOfWork, IReservationRepository reservationRepository)
        {
            _accommodationRepository = accommodationRepository;
            _unitOfWork = unitOfWork;
            _reservationRepository = reservationRepository;
        }

        public async Task<Result> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            Accommodation accommodation = await _accommodationRepository.GetAsync(request.AccommodationId);

            if (accommodation.ReservationApprovalRequired)
            {
                return Result.Failure(AccommodationErrors.ReservationRequiresApproval);
            }

            var slot = DateTimeSlot.Create(request.Start, request.End);

            var response = accommodation.AddReservation(slot.Value, request.GuestNumber, request.GuestId, null);

            if (response.IsSuccess)
            {
                await _reservationRepository.Add(response.Value);
                await _unitOfWork.SaveChangesAsync();
            }



            return response;

        }
    }
}
