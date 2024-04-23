using Booking.Accomodation.Application.Features.Accommodations.AddAvailabilityPeriod;
using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Accommodations.GetAccommodationAvailabilityPeriod
{
    internal class GetAccommodationAvailabilityPeriodQueryHandler : IQueryHandler<GetAccommodationAvailabilityPeriodQuery, List<AvailabilityPeriodResponse>>
    {
        private readonly IAccommodationRepository _accommodationRepository;

        public GetAccommodationAvailabilityPeriodQueryHandler(IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
        }

        public async Task<Result<List<AvailabilityPeriodResponse>>> Handle(GetAccommodationAvailabilityPeriodQuery request, CancellationToken cancellationToken)
        {
            Accommodation accommodation = await _accommodationRepository.GetAsync(request.AccommodationId);

            List<AvailabilityPeriod> periods = accommodation.AvailabilityPeriods;

            return periods.Select(x => new AvailabilityPeriodResponse(x.Id, x.AccommodationId, x.Slot, x.Price.ConvertToString())).ToList();
        }
    }
}
