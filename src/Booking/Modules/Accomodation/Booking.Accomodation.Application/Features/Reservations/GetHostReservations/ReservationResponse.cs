using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Accomodation.Application.Features.Reservations.GetHostReservations
{
    public sealed record ReservationResponse(Guid AccommodationId, string Accommodation,
        string Address, string Price, Guid ReservationId, DateTimeSlot Slot, Boolean ReviewExist)
    {
    }
}
