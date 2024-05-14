using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Commerce.Application.Features.Invoices.ReservationInvoices
{
    public sealed record GetPayerReservationInvoicesQuery(Guid PayerId) : IQuery<List<ReservationInvoiceResponse>>
    {
    }
}
