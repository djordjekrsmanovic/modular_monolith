using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Commerce.Domain.Entities
{
    public class SubscriptionPlan : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int AccomodationLimit { get; set; }

        public Money Price { get; set; }

        public int DurationInMonths { get; set; }
    }
}
