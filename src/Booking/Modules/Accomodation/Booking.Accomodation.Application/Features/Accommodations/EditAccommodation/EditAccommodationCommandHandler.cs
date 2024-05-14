using Booking.AccommodationNS.Domain;
using Booking.AccommodationNS.Domain.Repositories;
using Booking.AccommodationNS.Domain.ValueObjects;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.Enums;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.AccommodationNS.Application.Features.Accommodations.EditAccommodation
{
    internal class EditAccommodationCommandHandler : ICommandHandler<EditAccommodationCommand, Guid>
    {
        private readonly IAccommodationRepository _accommodationRepository;

        private readonly IUnitOfWork _unitOfWork;


        public EditAccommodationCommandHandler(IAccommodationRepository accommodationRepository, IUnitOfWork unitOfWork)
        {
            _accommodationRepository = accommodationRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Guid>> Handle(EditAccommodationCommand request, CancellationToken cancellationToken)
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

            Accommodation accommodation = await _accommodationRepository.GetAsync(request.Id);

            accommodation.UpdateAccommodation(request.Name, request.Description, pricePerGuestResponse.Value, guestCapacityResponse.Value, request.Images, addressResponse.Value, request.AdditionalServices, request.ReservationApprovalRequired);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success(accommodation.Id);
        }

    }
}
