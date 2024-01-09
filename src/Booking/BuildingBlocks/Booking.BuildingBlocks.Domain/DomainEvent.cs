
namespace Booking.BuildingBlocks.Domain
{
    public abstract record DomainEvent:IDomainEvent
    {
        protected DomainEvent()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
        }

        public Guid Id { get; }

        public DateTime OccurredOn { get; }
    }
}
