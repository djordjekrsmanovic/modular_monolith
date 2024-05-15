﻿namespace Booking.AccommodationNS.Application.Features.Accommodations.GetAccommodationById
{
    public sealed record ImageResponse(Guid Id, string Name, string Extension, string Content, string Hash)
    {
    }
}