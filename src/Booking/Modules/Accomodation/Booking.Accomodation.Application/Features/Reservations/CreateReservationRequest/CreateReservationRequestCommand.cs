using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Reservations.CreateReservationRequest
{
    public record CreateReservationRequestCommand(Guid AccommodationId, Guid GuestId, string Messsage, int GuestNumber, DateTime Start, DateTime End) : ICommand
    {
    }
}
