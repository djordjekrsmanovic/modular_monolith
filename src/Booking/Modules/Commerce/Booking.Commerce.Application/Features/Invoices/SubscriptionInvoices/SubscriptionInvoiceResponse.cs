using Booking.Commerce.Domain.Enums;

namespace Booking.Commerce.Application.Features.Invoices.SubscriptionInvoices
{
    public record SubscriptionInvoiceResponse(Guid InvoiceId, Guid SubscriptionId, string Price, PaymentMethod Method, DateTime CreatedAt)
    {
    }
}
