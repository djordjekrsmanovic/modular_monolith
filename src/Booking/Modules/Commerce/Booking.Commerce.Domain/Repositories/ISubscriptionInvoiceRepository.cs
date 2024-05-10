using Booking.Commerce.Domain.Entities;

namespace Booking.Commerce.Domain.Repositories
{
    public interface ISubscriptionInvoiceRepository
    {
        Task Add(SubscriptionInvoice invoice);
    }
}
