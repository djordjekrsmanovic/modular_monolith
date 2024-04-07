namespace Booking.BuildingBlocks.Application
{
    public record PagedQuery(string? SearchTerm,
    string? SortColumn,
    string? SortOrder,
    int Page,
    int PageSize)
    {
    }
}
