using Booking.Accomodation.Domain.Errors;
using Booking.Accomodation.Domain.Repositories;
using Booking.Accomodation.Domain.ValueObjects;
using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Accommodations.GetAccommodationById
{
    internal class GetAccommodationByIdQueryHandler : IQueryHandler<GetAccommodationByIdQuery, GetAccommodationByIdResponse>
    {
        private IAccommodationRepository _accommodationRepository;

        public GetAccommodationByIdQueryHandler(IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
        }

        public async Task<Result<GetAccommodationByIdResponse>> Handle(GetAccommodationByIdQuery request, CancellationToken cancellationToken)
        {
            Accommodation accommodation = await _accommodationRepository.GetAsync(request.Id);

            if (accommodation == null)
            {
                return Result.Failure<GetAccommodationByIdResponse>(AccommodationErrors.IdNotExist);
            }

            return new GetAccommodationByIdResponse
            (
                Id: accommodation.Id,
                Name: accommodation.Name,
                Description: accommodation.Description,
                Address: accommodation.Address.ConvertToString(),
                Price: accommodation.PricePerGuest.ConvertToString(),
                AdditionalServices: accommodation.AdditionalServices.Select(a => a.Name).ToList(),
                Raiting: accommodation.Raiting,
                Images: accommodation.Images.Select(img => { return img.ToBase64(); }).ToList(),
                AvailabilityPeriods: accommodation.AvailabilityPeriods.Select(a => { return DateTimeSlot.Create(a.Slot.Start, a.Slot.End).Value; }).ToList(),
                Reservations: accommodation.Reservations.Select(a => { return DateTimeSlot.Create(a.DateTimeSlot.Start, a.DateTimeSlot.End).Value; }).ToList(),
                HostId: accommodation.HostId
            );
        }
    }
}
