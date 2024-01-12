namespace Booking.BuildingBlocks.Domain
{
    public interface IEntity
    {
        void RaiseDomainEvent(IDomainEvent domainEvent);

        void ClearDomainEvents();

        IReadOnlyCollection<IDomainEvent> GetDomainEvents();
    }
}
