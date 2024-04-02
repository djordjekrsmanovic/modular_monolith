using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.Entities
{
    public class Guest : Entity<Guid>
    {

        public List<ReservationRequest> ReservationRequests { get; private set; }

        public List<Accommodation> VisitedAccomodations { get; private set; }

        public List<Accommodation> FavouriteAccomodations { get; private set; }


        private Guest() { }

        private Guest(Guid id)
        {
            Id = id;
            ReservationRequests = new List<ReservationRequest>();
            VisitedAccomodations = new List<Accommodation>();
            FavouriteAccomodations = new List<Accommodation>();
        }

        public static Guest Create(Guid id)
        {
            return new Guest(id);
        }

    }
}
