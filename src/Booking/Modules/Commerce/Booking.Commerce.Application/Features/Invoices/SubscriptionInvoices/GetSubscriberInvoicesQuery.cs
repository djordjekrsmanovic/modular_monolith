using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Commerce.Application.Features.Invoices.SubscriptionInvoices
{
    public sealed record GetSubscriberInvoicesQuery(Guid SubscriberId) : IQuery<List<SubscriptionInvoiceResponse>>
    {
    }
}
