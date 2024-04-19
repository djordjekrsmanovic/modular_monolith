using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Booking.Commerce.Infrastructure.Database.Repositories
{
    internal class SubscriptionPlanRepository : ISubscriptionPlanRepository
    {
        private CommerceDbContext _context;

        public SubscriptionPlanRepository(CommerceDbContext context)
        {
            _context = context;
        }
        public async Task<SubscriptionPlan> GetAsync(Guid id)
        {
            return await _context.Set<SubscriptionPlan>().FirstOrDefaultAsync(plan => plan.Id == id);
        }

        public async Task<List<SubscriptionPlan>> GetAsync()
        {
            return await _context.Set<SubscriptionPlan>().ToListAsync();
        }
    }
}
