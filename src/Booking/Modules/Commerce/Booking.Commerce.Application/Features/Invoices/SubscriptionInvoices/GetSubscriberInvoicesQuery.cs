using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Commerce.Application.Features.Invoices.SubscriptionInvoices
{
    public record GetSubscriberInvoicesQuery(Guid SubscriberId) : IQuery<List<SubscriptionInvoiceResponse>>
    {
    }
}
