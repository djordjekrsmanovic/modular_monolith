using Booking.Accomodation.Domain.ValueObjects;
using Booking.Booking.Domain.ValueObjects;
using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.Entities
{
    public class Accommodation : AgregateRoot<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Address Address { get; set; }

        public GuestCapacity Capacity { get; set; }

        public bool isBlocked { get; set; }

        public List<AdditionalService> AdditionalServices { get; set; } = new List<AdditionalService>();

        public Money PricePerGuest { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public List<ReservationRequest> ReservationRequests { get; set; } = new List<ReservationRequest>();

        public List<AvailabilityPeriod> AvailabilityPeriods { get; set; } = new List<AvailabilityPeriod>();

        public List<Image> Images { get; set; }

        public Guid HostId { get; set; }

        private Accommodation() { }

        private Accommodation(string name, string description, Address address, GuestCapacity capacity,
            Money pricePerGuest, List<Image> images, Guid hostId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Address = address;
            Capacity = capacity;
            PricePerGuest = pricePerGuest;
            Images = images;
            HostId = hostId;

        }

        public static Result<Accommodation> Create(Guid hostId, string name, string description,
            Money pricePerGuest, GuestCapacity capacity, List<Image> images, Address address)
        {
            return new Accommodation(name, description, address, capacity, pricePerGuest, images, hostId);
        }
    }
}
