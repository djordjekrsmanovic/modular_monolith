namespace Booking.Accomodation.Application.Features.Accommodations.GetAccommodationById
{
    public record ImageResponse(Guid Id, string Name, string Extension, string Content, string Hash)
    {
    }
}