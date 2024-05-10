using Booking.Commerce.Domain.Enums;

namespace Booking.Commerce.Application.Features.Invoices.ReservationInvoices
{
    public record ReservationInvoiceResponse(Guid InvoiceId, Guid ReservationId, string Price, PaymentMethod Method, DateTime CreatedAt)
    {
    }
}
