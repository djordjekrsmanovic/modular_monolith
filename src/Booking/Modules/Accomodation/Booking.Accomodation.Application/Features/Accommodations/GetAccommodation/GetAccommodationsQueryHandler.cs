using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Accommodations.GetAccommodation
{
    internal class GetAccommodationsQueryHandler : IQueryHandler<GetAccommodationsQuery, List<AccommodationResponse>>
    {
        private readonly IAccommodationRepository _accommodationRepository;

        public GetAccommodationsQueryHandler(IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
        }

        public async Task<Result<List<AccommodationResponse>>> Handle(GetAccommodationsQuery request, CancellationToken cancellationToken)
        {
            List<Accommodation> accommodations = await _accommodationRepository.Get(request.SearchTerm, request.SortColumn, request.SortOrder, request.Page,
               request.PageSize,
               request.StartDate,
               request.EndDate,
               request.Country);


            accommodations = accommodations.Where(accommodation => accommodation.IsAvailableForBooking(request.StartDate, request.EndDate)).ToList();

            if (request.AdditionalServices is not null && request.AdditionalServices.Any())
            {
                accommodations = accommodations.Where(accommodation =>
                {
                    // Extract names of additional services for the current accommodation
                    var accommodationServiceNames = accommodation.AdditionalServices.Select(x => x.Name);

                    // Find the common service names between accommodation and request
                    var commonServiceNames = accommodationServiceNames.Intersect(request.AdditionalServices);

                    // Check if the count of common service names matches the count of additional services in the request
                    bool hasAllRequestedServices = commonServiceNames.Count() == request.AdditionalServices.Count;

                    return hasAllRequestedServices;
                }).ToList();
            }


            List<AccommodationResponse> accommodationResponses = accommodations
                .Select(x =>
                {
                    return new AccommodationResponse(x.Id, x.Name, x.Description, x.Address.ConvertToString(), x.PricePerGuest.ConvertToString(), x.AdditionalServices.Select(x => x.Name).ToList(), x.Raiting, x.Images.FirstOrDefault().ToBase64());

                })
                .ToList();

            return Result<List<AccommodationResponse>>.Success(accommodationResponses);
        }
    }
}
