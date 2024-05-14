﻿namespace Booking.AccommodationNS.Presentation.Contracts
{
    public record CreateReviewRequest(Guid ReservationId, Guid GuestId, string Comment, int Rating)
    {
    }
}
