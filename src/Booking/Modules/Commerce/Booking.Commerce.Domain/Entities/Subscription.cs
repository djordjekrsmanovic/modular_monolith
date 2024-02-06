using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel;
using Booking.Commerce.Domain.Enums;

namespace Booking.Commerce.Domain.Entities
{
    public class Subscription : Entity<Guid>
    {
        public DateTimeSlot SubscriptionPeriod { get; set; }

        public SubscriptionStatus Status { get; set; }

        public SubscriptionPlan Plan { get; set; }
    }
}
