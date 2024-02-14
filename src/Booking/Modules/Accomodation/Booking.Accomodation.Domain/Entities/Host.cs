using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.Entities
{
    public class Host : Entity<Guid>
    {

        public Guid UserId { get; set; }

        public List<Accomodation> Accomodations { get; private set; }

        private Host() { }
        private Host(Guid userId)
        {
            Id = Guid.NewGuid();
            Accomodations = new List<Accomodation>();
            UserId = Guid.NewGuid();
        }

        public static Host Create(Guid id)
        {
            return new Host(id);
        }


    }
}
