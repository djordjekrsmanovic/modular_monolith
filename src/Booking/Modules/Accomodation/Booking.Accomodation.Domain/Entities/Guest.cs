using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.Entities
{
    public class Guest : Entity<Guid>
    {
        public List<ReservationRequest> ReservationRequests { get; private set; }

        private Guest() { }

        private Guest(Guid id)
        {
            Id = id;
            ReservationRequests = new List<ReservationRequest>();
        }

        public static Guest Create(Guid id)
        {
            return new Guest(id);
        }

    }
}
