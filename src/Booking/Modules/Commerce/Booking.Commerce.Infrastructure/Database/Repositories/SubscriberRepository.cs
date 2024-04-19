using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Booking.Commerce.Infrastructure.Database.Repositories
{
    internal class SubscriberRepository : ISubscriberRepository
    {
        private readonly DbSet<Subscriber> _subscribers;

        public SubscriberRepository(CommerceDbContext context)
        {
            _subscribers = context.Set<Subscriber>();
        }

        public void Add(Subscriber subscriber)
        {
            _subscribers.Add(subscriber);
            Console.WriteLine("Command add subscriber executed");
        }

        public async Task<Subscriber> GetAsync(Guid id)
        {
            return _subscribers.Include(s => s.Subscriptions)
                .ThenInclude(s => s.Plan)
                .Include(s => s.Subscriptions)
                .ThenInclude(sub => sub.Payments).FirstOrDefault(s => s.Id == id);
        }
    }
}
