namespace Booking.AccommodationNS.Application.Features.Accommodations.GetAccommodation
{
    public sealed record AccommodationResponse(Guid Id, string Name, string Description, string Address, string Price, List<string> AdditionalServices, Double Raiting, string image)
    {
    }
}