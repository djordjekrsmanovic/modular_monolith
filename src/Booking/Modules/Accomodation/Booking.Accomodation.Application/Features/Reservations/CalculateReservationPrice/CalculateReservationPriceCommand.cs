using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Reservations.CalculateReservationPrice
{
    public sealed record CalculateReservationPriceCommand(Guid AccommodationId, DateTime Start, DateTime End, int GuestNumber) : ICommand<string>
    {
    }
}
