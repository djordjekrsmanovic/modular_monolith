using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Commerce.Application.Features.Reservations.ConfirmPayment
{
    public record ConfirmPaymentCommand(Guid ReservationId) : ICommand
    {
    }
}
