using Booking.AccommodationNS.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.AccommodationNS.Application.Features.Accommodations.GetAdditionalServices
{
    internal class GetAdditionalServicesQueryHandler : IQueryHandler<GetAdditionalServicesQuery, List<AdditionalService>>
    {
        private readonly IAdditionalServiceRepository _repository;

        public GetAdditionalServicesQueryHandler(IAdditionalServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<AdditionalService>>> Handle(GetAdditionalServicesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAsync();
        }
    }
}
