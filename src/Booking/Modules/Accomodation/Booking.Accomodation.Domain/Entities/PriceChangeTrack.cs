using Booking.Booking.Domain.ValueObjects;
using Booking.BuildingBlocks.Domain;

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
