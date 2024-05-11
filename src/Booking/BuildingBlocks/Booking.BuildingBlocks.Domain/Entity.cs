
namespace Booking.BuildingBlocks.Domain
{
    public abstract class Entity<TEntity> : IEntity
    {

        private readonly List<IDomainEvent> _domainEvents = new();
        public TEntity Id { get; protected set; }

        protected Entity() { }

        protected Entity(TEntity id)
        {
            Id = id;
        }

        public void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.AsReadOnly();
    }
}
