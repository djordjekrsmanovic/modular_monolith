using Booking.Accomodation.Domain.Errors;
using Booking.Accomodation.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Accomodation.Application.Features.Reservations.CalculateReservationPrice
{
    internal class CalculateReservationPriceCommandHandler : ICommandHandler<CalculateReservationPriceCommand, string>
    {
        private readonly IAccommodationRepository _accommodationRepository;

        public CalculateReservationPriceCommandHandler(IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
        }

        public async Task<Result<string>> Handle(CalculateReservationPriceCommand request, CancellationToken cancellationToken)
        {
            Accommodation accommodation = await _accommodationRepository.GetAsync(request.AccommodationId);

            AvailabilityPeriod period = accommodation.AvailabilityPeriods.Where(x => x.Slot.IsDateInSlot(request.Start)).FirstOrDefault();

            if (period is null)
            {
                return Result.Failure<string>(AvailabilityPeriodErrors.PeriodNotExist);
            }

            var slotResponse = DateTimeSlot.Create(request.Start, request.End);

            if (slotResponse.IsFailure)
            {
                return Result.Failure<string>(slotResponse.Error);
            }

            var calculatedPrice = Money.CalculateSumPriceForReservation(accommodation.PricePerGuest, request.GuestNumber, slotResponse.Value.GetNumberOfDays());

            return Result.Success(calculatedPrice.ConvertToString());
        }
    }
}
