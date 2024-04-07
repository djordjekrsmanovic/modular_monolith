using Booking.Accomodation.Domain;
using Booking.Accomodation.Domain.Repositories;
using Booking.Accomodation.Domain.ValueObjects;
using Booking.Booking.Domain.Entities;
using Booking.Booking.Domain.Enums;
using Booking.Booking.Domain.ValueObjects;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.AccommodationNS.AddAccommodation
{
    internal class AddAccommodationCommandHandler : ICommandHandler<AddAccommodationCommand, Guid>
    {
        private readonly IAccommodationRepository _accommodationRepository;

        private readonly IUnitOfWork _unitOfWork;

        public AddAccommodationCommandHandler(IAccommodationRepository accommodationRepository, IUnitOfWork unitOfWork)
        {
            _accommodationRepository = accommodationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(AddAccommodationCommand request, CancellationToken cancellationToken)
        {
            var addressResponse = Address.Create(request.Street, request.City, request.Country);

            if (addressResponse.IsFailure)
            {
                return Result.Failure<Guid>(addressResponse.Error);
            }

            var pricePerGuestResponse = Money.Create(Currency.EUR, request.PricePerGuest);

            if (pricePerGuestResponse.IsFailure)
            {
                return Result.Failure<Guid>(pricePerGuestResponse.Error);
            }

            var guestCapacityResponse = GuestCapacity.Create(request.MinGuest, request.MaxGuest);

            if (guestCapacityResponse.IsFailure)
            {
                return Result.Failure<Guid>(guestCapacityResponse.Error);
            }


            Result<Accommodation> accommodation = Accommodation.Create(request.hostId, request.Name, request.Description, pricePerGuestResponse.Value, guestCapacityResponse.Value, request.Images, addressResponse.Value, request.AdditionalServices);

            if (accommodation.IsFailure)
            {
                return Result.Failure<Guid>(accommodation.Error);

            }

            foreach (var image in accommodation.Value.Images)
            {
                image.AddImageToAccommodation(accommodation.Value.Id);
            }

            await _accommodationRepository.Add(accommodation.Value);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success(accommodation.Value.Id);
        }
    }
}
