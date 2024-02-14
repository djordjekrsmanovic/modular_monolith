using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Infrastructure.Database.Repositories
{
    internal class SubscriberRepository : ISubscriberRepository
    {
        private readonly CommerceDbContext _context;

        public SubscriberRepository(CommerceDbContext context)
        {
            _context = context;
        }

        public async Task Add(Subscriber subscriber)
        {
            _context.Add(subscriber);
        }
    }
}
