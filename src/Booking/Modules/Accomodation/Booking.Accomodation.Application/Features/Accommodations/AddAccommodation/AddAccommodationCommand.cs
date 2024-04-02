using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.AccommodationNS.AddAccommodation
{
    public record AddAccommodationCommand(string Name, string Description, string Street, string City,
        String Country, int MinGuest, int MaxGuest, Double PricePerGuest, List<AdditionalService> additionalServices,
        Guid hostId, List<Image> Images) : ICommand<Guid>
    {
    }
}
