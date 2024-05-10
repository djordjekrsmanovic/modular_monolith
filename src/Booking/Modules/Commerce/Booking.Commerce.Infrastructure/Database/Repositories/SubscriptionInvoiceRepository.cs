using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Infrastructure.Database.Repositories
{
    internal class SubscriptionInvoiceRepository : ISubscriptionInvoiceRepository
    {
        private readonly CommerceDbContext _context;

        public SubscriptionInvoiceRepository(CommerceDbContext context)
        {
            _context = context;
        }

        public async Task Add(SubscriptionInvoice invoice)
        {
            _context.Set<SubscriptionInvoice>().Add(invoice);
        }
    }
}
