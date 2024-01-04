
namespace Booking.BuildingBlocks.Domain
{
    public abstract record DomainEvent:IDomainEvent
    {
        protected DomainEvent(Guid id, DateTime occurredOnUtc)
        : this()
        {
            Id = id;
            OccurredOn = occurredOnUtc;
        }

        private DomainEvent()
        {
        }

        public Guid Id { get; private set; }

        public DateTime OccurredOn { get; private set; }
    }
}
