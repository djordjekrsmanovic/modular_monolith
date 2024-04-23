using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Reservations.CreateReservation
{
    internal class CreateReservationCommandHandler : ICommandHandler<CreateReservationCommand>
    {

        private readonly IAccommodationRepository _accommodationRepository;


        public async Task<Result> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            Accommodation accommodation = await _accommodationRepository.GetAsync(request.AccommodationId);

            return Result.Success();

        }
    }
}
