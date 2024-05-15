using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.AccommodationNS.Application.Features.Accommodations.GetAdditionalServices
{
    public sealed class GetAdditionalServicesQuery : IQuery<List<AdditionalService>>
    {
    }
}
