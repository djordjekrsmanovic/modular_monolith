using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Commerce.Domain.Entities
{
    public class SubscriptionPlan : Entity<Guid>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public int AccomodationLimit { get; private set; }

        public Money Price { get; private set; }

        public int DurationInMonths { get; private set; }

        private SubscriptionPlan() { }
    }
}
