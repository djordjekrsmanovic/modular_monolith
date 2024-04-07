using Booking.BuildingBlocks.Application;
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Accommodations.GetAccommodation
{
    public record GetAccommodationsQuery(string? SearchTerm,
    string? SortColumn,
    string? SortOrder,
    int Page,
    int PageSize,
    DateTime StartDate,
    DateTime EndDate,
    string? Country,
    List<string>? AdditionalServices
    ) : PagedQuery(SearchTerm, SortColumn, SortOrder, Page, PageSize), IQuery<List<AccommodationResponse>>
    {
    }
}
