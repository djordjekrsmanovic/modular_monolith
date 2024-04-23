using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Accommodations.EditAccommodation
{
    public record EditAccommodationCommand(Guid Id, string Name, string Description, string Street, string City,
        String Country, int MinGuest, int MaxGuest, Double PricePerGuest, List<AdditionalService> AdditionalServices,
        Guid hostId, List<Image> Images, bool ReservationApprovalRequired) : ICommand<Guid>
    {
    }
}
