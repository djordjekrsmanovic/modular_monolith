using Booking.Accomodation.Domain;
using Booking.Accomodation.Domain.Errors;
using Booking.Accomodation.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Accomodation.Application.Features.Accommodations.AddAvailabilityPeriod
{
    internal class AddAvailabilityPeriodCommandHandler : ICommandHandler<AddAvailabilityPeriodCommand, AvailabilityPeriodResponse>
    {

        private readonly IAccommodationRepository _accommodationRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IHostRepository _hostRepository;

        private readonly IAvailabilityPeriodRepository _availibalitiyPeriodRepository;

        public AddAvailabilityPeriodCommandHandler(IAccommodationRepository accommodationRepository,
            IUnitOfWork unitOfWork, IHostRepository hostRepository, IAvailabilityPeriodRepository availabilityPeriodRepository)
        {
            _accommodationRepository = accommodationRepository;
            _unitOfWork = unitOfWork;
            _hostRepository = hostRepository;
            _availibalitiyPeriodRepository = availabilityPeriodRepository;
        }

        public async Task<Result<AvailabilityPeriodResponse>> Handle(AddAvailabilityPeriodCommand request, CancellationToken cancellationToken)
        {
            Accommodation accommodation = await _accommodationRepository.GetAsync(request.AccommodationId);

            Host host = await _hostRepository.GetByIdAsync(accommodation.HostId);

            if (accommodation is null)
            {
                return Result.Failure<AvailabilityPeriodResponse>(AccommodationErrors.IdNotExist);
            }

            Accommodation firstCreatedAccommodation = await _accommodationRepository.GetFirstAccommodation(request.AccommodationId);

            AvailabilityPeriod period;

            if (accommodation.Id == firstCreatedAccommodation.Id)
            {
                var availabilityPeriodResponse = accommodation.AddAvailabilityPeriod(request.Start, request.End, Money.Create(BuildingBlocks.Domain.Enums.Currency.EUR, request.PricePerGuest).Value);
                if (availabilityPeriodResponse.IsSuccess)
                {
                    period = availabilityPeriodResponse.Value;
                }
                else
                {
                    return Result.Failure<AvailabilityPeriodResponse>(availabilityPeriodResponse.Error);
                }
            }
            else
            {
                var availabilityPeriodResponse = accommodation.AddAvailabilityPeriod(request.Start, request.End, Money.Create(BuildingBlocks.Domain.Enums.Currency.EUR, request.PricePerGuest).Value, host.SubscriptionExpirationDate);
                if (availabilityPeriodResponse.IsSuccess)
                {
                    period = availabilityPeriodResponse.Value;
                }
                else
                {
                    return Result.Failure<AvailabilityPeriodResponse>(availabilityPeriodResponse.Error);
                }
            }

            await _availibalitiyPeriodRepository.Add(period);

            await _unitOfWork.SaveChangesAsync();

            return new AvailabilityPeriodResponse(Id: period.Id, AccommodationId: period.AccommodationId, Slot: period.Slot, Price: period.Price.ConvertToString());
        }
    }
}
