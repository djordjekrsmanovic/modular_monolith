using Booking.Booking.Domain.ValueObjects;
using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.Entities
{
    public class Host : Entity<Guid>
    {
        public Guid UserId { get; private set; }

        public List<Accomodation> Accomodations { get; private set; }

        public Address Address { get; private set; }

    }
}
