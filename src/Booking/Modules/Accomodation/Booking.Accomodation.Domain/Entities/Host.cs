using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.Entities
{
    public class Host : Entity<Guid>
    {
        public List<Accommodation> Accomodations { get; private set; }

        private Host() { }
        private Host(Guid id)
        {
            Id = id;
            Accomodations = new List<Accommodation>();

        }

        public static Host Create(Guid userId)
        {
            return new Host(userId);
        }


    }
}
