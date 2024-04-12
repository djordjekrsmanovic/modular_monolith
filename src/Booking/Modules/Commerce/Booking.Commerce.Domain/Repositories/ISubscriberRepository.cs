using Booking.Commerce.Domain.Entities;

namespace Booking.Commerce.Domain.Repositories
{
    public interface ISubscriberRepository
    {
        void Add(Subscriber subscriber);
        Task<Subscriber> GetAsync(Guid id);
    }
}
