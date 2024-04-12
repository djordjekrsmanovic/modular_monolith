using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Infrastructure.Database.Repositories
{
    internal class SubscriptionRepository : ISubscriptionRepository
    {
        private CommerceDbContext _context;

        public SubscriptionRepository(CommerceDbContext context)
        {
            _context = context;
        }
        public async Task Add(Subscription subscription)
        {
            _context.Add(subscription);
        }
    }
}
