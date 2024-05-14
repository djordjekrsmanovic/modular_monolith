using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.AccommodationNS.AddAccommodation
{
    public sealed record AddAccommodationCommand(string Name, string Description, string Street, string City,
        String Country, int MinGuest, int MaxGuest, Double PricePerGuest, List<AdditionalService> AdditionalServices,
        Guid hostId, List<Image> Images, bool ReservationApprovalRequired) : ICommand<Guid>
    {
    }
}
