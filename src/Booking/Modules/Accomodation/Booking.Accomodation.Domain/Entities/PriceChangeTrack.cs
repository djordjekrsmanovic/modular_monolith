using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Accomodation.Domain.Entities
{
    public class PriceChangeTrack : Entity<Guid>
    {
        public Money OldPrice { get; set; }

        public Money NewPrice { get; set; }

        public DateTime OccuredOn { get; set; }

        public Guid AccomodationId { get; set; }
    }
}
