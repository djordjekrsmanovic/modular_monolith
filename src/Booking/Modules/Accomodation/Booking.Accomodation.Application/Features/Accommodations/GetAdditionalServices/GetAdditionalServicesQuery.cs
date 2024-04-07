using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Accommodations.GetAdditionalServices
{
    public class GetAdditionalServicesQuery : IQuery<List<AdditionalService>>
    {
    }
}
