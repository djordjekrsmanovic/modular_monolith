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

    }
}
