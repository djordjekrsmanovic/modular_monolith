using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Subscription> GetAsync(Guid Id)
        {
            return await _context.Set<Subscription>().Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
    }
}
