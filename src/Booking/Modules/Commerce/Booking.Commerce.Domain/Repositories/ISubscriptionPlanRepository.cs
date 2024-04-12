using Booking.Commerce.Domain.Entities;

namespace Booking.Commerce.Domain.Repositories
{
    public interface ISubscriptionPlanRepository
    {
        Task<SubscriptionPlan> GetAsync(Guid id);

        Task<List<SubscriptionPlan>> GetAsync();
    }
}
