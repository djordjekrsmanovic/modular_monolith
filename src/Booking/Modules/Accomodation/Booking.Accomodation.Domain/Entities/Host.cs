using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.Entities
{
    public class Host : Entity<Guid>
    {

        public List<Accomodation> Accomodations { get; private set; }

        private Host() { }
        private Host(Guid id)
        {
            Id = id;
            Accomodations = new List<Accomodation>();
        }

        public static Host Create(Guid id)
        {
            return new Host(id);
        }


    }
}
