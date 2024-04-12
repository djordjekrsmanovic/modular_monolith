using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;

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
            return _context.Set<SubscriptionPlan>().FirstOrDefault(plan => plan.Id == id);
        }
    }
}
