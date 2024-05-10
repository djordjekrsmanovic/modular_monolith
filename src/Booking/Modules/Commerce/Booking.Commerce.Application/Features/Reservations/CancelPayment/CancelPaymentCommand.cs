using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Commerce.Application.Features.Reservations.CancelPayment
{
    public record CancelPaymentCommand(Guid ReservationId) : ICommand
    {
    }
}
