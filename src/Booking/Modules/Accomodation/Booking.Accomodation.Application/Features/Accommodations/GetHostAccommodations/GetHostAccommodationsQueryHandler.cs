using Booking.Accomodation.Application.Features.Accommodations.GetAccommodation;
using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Accommodations.GetHostAccommodations
{
    internal class GetHostAccommodationsQueryHandler : IQueryHandler<GetHostAccommodationsQuery, List<AccommodationResponse>>
    {

        private readonly IAccommodationRepository _accommodationRepository;

        public GetHostAccommodationsQueryHandler(IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
        }

        public async Task<Result<List<AccommodationResponse>>> Handle(GetHostAccommodationsQuery request, CancellationToken cancellationToken)
        {
            List<Accommodation> accommodations = await _accommodationRepository.GetHostAccommodations(request.HostId);

            return accommodations
                .Select(x =>
                {
                    return new AccommodationResponse(x.Id, x.Name, x.Description, x.Address.ConvertToString(), x.PricePerGuest.ConvertToString(), x.AdditionalServices.Select(x => x.Name).ToList(), x.Raiting, x.Images.FirstOrDefault().ToBase64());

                })
                .ToList();

        }
    }
}
