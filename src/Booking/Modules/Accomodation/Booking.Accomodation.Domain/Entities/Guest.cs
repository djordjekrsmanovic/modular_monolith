using Booking.Booking.Domain.ValueObjects;
using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.Entities
{
    public class Guest : Entity<Guid>
    {
        public Address Address { get; private set; }

        public List<ReservationRequest> ReservationRequests { get; private set; }

        public List<Accomodation> VisitedAccomodations { get; private set; }

        public List<Accomodation> FavouriteAccomodations { get; private set; }


        private Guest() { }

        private Guest(Guid id)
        {
            Id = id;
            ReservationRequests = new List<ReservationRequest>();
            VisitedAccomodations = new List<Accomodation>();
            FavouriteAccomodations = new List<Accomodation>();
            Address = Address.CreateEmptyAdress();
        }

        public static Guest Create(Guid id)
        {
            return new Guest(id);
        }

    }
}
