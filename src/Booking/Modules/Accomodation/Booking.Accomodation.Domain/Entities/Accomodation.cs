using Booking.Booking.Domain.ValueObjects;
using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.Entities
{
    public class Accomodation : AgregateRoot<Guid>
    {
        public string Name { get; set; }

        public Address Address { get; set; }

        public int MinGuests { get; set; }

        public int MaxGuests { get; set; }

        public bool isBlocked { get; set; }

        public string Description { get; set; }

        public List<Facility> Facilities { get; set; }

        public Money PricePerGuest { get; set; }

        public List<Reservation> Reservations { get; set; }

        public List<ReservationRequest> ReservationRequests { get; set; }

        public List<AvailabilityPeriod> AvailabilityPeriods { get; set; }

        public List<Photo> Photos { get; set; }

        public Guid HostId { get; set; }
    }
}
