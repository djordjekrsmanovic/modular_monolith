using Booking.Commerce.Domain.Entities;

namespace Booking.Commerce.Domain.Repositories
{
    public interface ISubscriberRepository
    {
        Task Add(Subscriber subscriber);
    }
}
