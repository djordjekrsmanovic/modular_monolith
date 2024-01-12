namespace Booking.BuildingBlocks.Application.EventBus
{
    public abstract record IntegrationEvent:IIntegrationEvent
    {
        public Guid Id { get;}

        public DateTime OccurredOn { get;}

        protected IntegrationEvent()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
        }
    }
}
