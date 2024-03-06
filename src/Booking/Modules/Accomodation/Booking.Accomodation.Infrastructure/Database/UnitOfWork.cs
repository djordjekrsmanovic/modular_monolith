using Booking.Accomodation.Domain;
using Booking.Booking.Infrastructure.Database;
using Booking.BuildingBlocks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Booking.Accomodation.Infrastructure.Database
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AccomodationDbContext _context;

        private readonly IPublisher _publisher;

        public UnitOfWork(AccomodationDbContext dbContext, IPublisher publisher)
        {
            _context = dbContext;
            _publisher = publisher;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ExcludeStaticEntitiesFromTracking();

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


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
                entry.State = EntityState.Detached;
            }
        }
    }
}
