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

        public Double Raiting { get; set; }

        private Accommodation() { }

        private Accommodation(string name, string description, Address address, GuestCapacity capacity,
            Money pricePerGuest, List<Image> images, Guid hostId, List<AdditionalService> additionalServices)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Address = address;
            Capacity = capacity;
            PricePerGuest = pricePerGuest;
            Images = images;
            HostId = hostId;
            AdditionalServices = additionalServices;
            Raiting = 0;
        }

        public static Result<Accommodation> Create(Guid hostId, string name, string description,
            Money pricePerGuest, GuestCapacity capacity, List<Image> images, Address address, List<AdditionalService> additionalServices)
        {
            Accommodation accommodation = new Accommodation(name, description, address, capacity, pricePerGuest, images, hostId, additionalServices);
            AvailabilityPeriod availabilityPeriod = AvailabilityPeriod.Create(DateTime.UtcNow, DateTime.UtcNow.AddYears(1), pricePerGuest, accommodation.Id).Value;
            accommodation.AddAvailabilityPeriod(availabilityPeriod);
            return accommodation;
        }

        public bool IsAvailableForBooking(DateTime startDate, DateTime endDate)
        {
            bool currentReservationNotExist = true;
            bool availibilityPeriodsExists = AvailabilityPeriods.Where(x => x.Slot.isInRange(startDate, endDate)).ToList().Count != 0;
            if (Reservations.Count != 0)
            {
                currentReservationNotExist = Reservations.Where(x => !x.DateTimeSlot.isInRange(startDate, endDate)).ToList().Count == 0;
            }

            return availibilityPeriodsExists && currentReservationNotExist;
        }

        public void AddAvailabilityPeriod(AvailabilityPeriod period)
        {
            AvailabilityPeriods.Add(period);
        }
    }
}
