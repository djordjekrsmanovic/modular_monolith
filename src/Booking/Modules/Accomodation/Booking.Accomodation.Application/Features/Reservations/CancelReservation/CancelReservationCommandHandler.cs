using Booking.Accomodation.Domain;
using Booking.Accomodation.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Reservations.CancelReservation
{
    public class CancelReservationCommandHandler : ICommandHandler<CancelReservationCommand>
    {

        private readonly IAccommodationRepository _accommodationRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CancelReservationCommandHandler(IAccommodationRepository accommodationRepository, IUnitOfWork unitOfWork)
        {
            _accommodationRepository = accommodationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CancelReservationCommand request, CancellationToken cancellationToken)
        {
            Accommodation accommodation = await _accommodationRepository.GetAsync(request.AccommodationId);

            var response = accommodation.CancelReservation(request.ReservationId);

            await _unitOfWork.SaveChangesAsync();

            return response;
        }
    }
}
