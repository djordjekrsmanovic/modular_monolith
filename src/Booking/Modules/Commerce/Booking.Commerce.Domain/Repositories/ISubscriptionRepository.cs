using Booking.Commerce.Domain.Entities;

namespace Booking.Commerce.Domain.Repositories
{
    public interface ISubscriptionRepository
    {
        Task Add(Subscription subscription);
        Task<Subscription> GetAsync(Guid Id);
    }
}
