using Booking.Accomodation.Domain;
using Booking.Accomodation.Domain.Errors;
using Booking.Accomodation.Domain.Repositories;
using Booking.Accomodation.Domain.ValueObjects;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.Enums;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Accomodation.Application.Features.AccommodationNS.AddAccommodation
{
    internal class AddAccommodationCommandHandler : ICommandHandler<AddAccommodationCommand, Guid>
    {
        private readonly IAccommodationRepository _accommodationRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IHostRepository _hostRepository;

        public AddAccommodationCommandHandler(IAccommodationRepository accommodationRepository, IUnitOfWork unitOfWork, IHostRepository hostRepository)
        {
            _accommodationRepository = accommodationRepository;
            _unitOfWork = unitOfWork;
            _hostRepository = hostRepository;
        }

        public async Task<Result<Guid>> Handle(AddAccommodationCommand request, CancellationToken cancellationToken)
        {
            Host host = await _hostRepository.GetByIdAsync(request.hostId);

            if (!host.IsAllowedToCreateAccommodation(_accommodationRepository.GetNumberOfHostAccommodations(request.hostId)))
            {
                return Result.Failure<Guid>(AccommodationErrors.AccommodationLimitExceeded);
            }

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


            Result<Accommodation> accommodation = Accommodation.Create(request.hostId, request.Name, request.Description, pricePerGuestResponse.Value, guestCapacityResponse.Value, request.Images, addressResponse.Value, request.AdditionalServices, request.ReservationApprovalRequired);

            if (accommodation.IsFailure)
            {
                return Result.Failure<Guid>(accommodation.Error);

            }

            AddAvailabilityPeriod(host, pricePerGuestResponse.Value, accommodation.Value);

            AddImages(accommodation);

            await _accommodationRepository.Add(accommodation.Value);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success(accommodation.Value.Id);
        }

        private static void AddImages(Result<Accommodation> accommodation)
        {
            foreach (var image in accommodation.Value.Images)
            {
                image.AddImageToAccommodation(accommodation.Value.Id);
            }
        }

        private static void AddAvailabilityPeriod(Host host, Money pricePerGuest, Accommodation accommodation)
        {
            DateTime endDate = host.AccommodationLimit == 1 ? DateTime.UtcNow.AddYears(1) : host.SubscriptionExpirationDate;

            accommodation.AddAvailabilityPeriod(DateTime.UtcNow, endDate, pricePerGuest);
        }
    }
}
