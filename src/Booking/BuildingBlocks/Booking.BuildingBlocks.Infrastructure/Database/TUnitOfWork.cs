using Booking.BuildingBlocks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Booking.BuildingBlocks.Infrastructure.Database
{
    public class TUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly TContext _context;

        private IPublisher _publisher;

        public TUnitOfWork(TContext dbContext, IPublisher publisher)
        {
            _context = dbContext;
            _publisher = publisher;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ExcludeStaticEntitiesFromTracking();


            await _context.SaveChangesAsync(cancellationToken);

            await PublishDomainEvents(cancellationToken);

        }

        private async Task PublishDomainEvents(CancellationToken cancellationToken)
        {
            List<IDomainEvent> domainEvents = _context.ChangeTracker.Entries<IEntity>()
                            .Select(x => x.Entity)
                            .SelectMany(x => x.GetDomainEvents()).ToList();

            //delete events to avoid publishing again
            _context.ChangeTracker.Entries<IEntity>()
                   .ToList()
                   .ForEach(entry => entry.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }
        }

        private void ExcludeStaticEntitiesFromTracking()
        {
            var entries = _context
                        .ChangeTracker.Entries<IStaticEntity>()
                            .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
            foreach (var entry in entries)
            {
                entry.State = EntityState.Detached; ;
            }
        }
    }
}
