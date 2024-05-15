using Booking.AccommodationNS.Domain.Entities;

namespace Booking.AccommodationNS.Application.Features.Reservations.GetHostReservationRequests
{
    public sealed record ReservationRequestResponse(string accommodation, ReservationRequest Request)
    {
    }
}