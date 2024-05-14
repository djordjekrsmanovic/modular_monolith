using Booking.BuildingBlocks.Application;
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.AccommodationNS.Application.Features.Accommodations.GetAccommodation
{
    public sealed record GetAccommodationsQuery(string? SearchTerm,
    string? SortColumn,
    string? SortOrder,
    int Page,
    int PageSize,
    DateTime StartDate,
    DateTime EndDate,
    string? Country,
    int GuestNumber,
    List<string>? AdditionalServices
    ) : PagedQuery(SearchTerm, SortColumn, SortOrder, Page, PageSize), IQuery<List<AccommodationResponse>>
    {
    }
}
