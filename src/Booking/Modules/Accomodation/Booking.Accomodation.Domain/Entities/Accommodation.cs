using Booking.Accomodation.Domain.ValueObjects;
using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Booking.Domain.Entities
{
    public class Accommodation : AgregateRoot<Guid>
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public Address Address { get; set; }

        public GuestCapacity Capacity { get; set; }

        public bool IsBlocked { get; set; }

        public List<AdditionalService> AdditionalServices { get; set; } = new List<AdditionalService>();

        public Money PricePerGuest { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public List<ReservationRequest> ReservationRequests { get; set; } = new List<ReservationRequest>();

        public List<AvailabilityPeriod> AvailabilityPeriods { get; set; } = new List<AvailabilityPeriod>();

        public List<Image> Images { get; set; }

        public Guid HostId { get; set; }

        public Double Raiting { get; set; }

        public bool ReservationApprovalRequired { get; set; }

        public DateTime CreatedAt { get; set; }

        private Accommodation() { }

        private Accommodation(string name, string description, Address address, GuestCapacity capacity,
            Money pricePerGuest, List<Image> images, Guid hostId, List<AdditionalService> additionalServices, bool reservationApprovalRequired)
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
            ReservationApprovalRequired = reservationApprovalRequired;
            CreatedAt = DateTime.Now;
        }

        public static Result<Accommodation> Create(Guid hostId, string name, string description,
            Money pricePerGuest, GuestCapacity capacity, List<Image> images, Address address,
            List<AdditionalService> additionalServices, bool reservationApprovalRequired)
        {
            Accommodation accommodation = new Accommodation(name, description, address, capacity, pricePerGuest, images, hostId, additionalServices, reservationApprovalRequired);
            return accommodation;
        }

        public bool IsAvailableForBooking(DateTime startDate, DateTime endDate)
        {
            bool currentReservationNotExist = true;
            bool availibilityPeriodsExists = AvailabilityPeriods.Where(x => x.Slot.IsRangeOverlapping(startDate, endDate)).ToList().Count != 0;
            if (Reservations.Count != 0)
            {
                currentReservationNotExist = Reservations.Where(x => !x.DateTimeSlot.IsRangeOverlapping(startDate, endDate)).ToList().Count == 0;
            }

            return availibilityPeriodsExists && currentReservationNotExist;
        }

        public Result AddAvailabilityPeriod(DateTime start, DateTime end, Money Price)
        {
            var availabilityPeriodResponse = AvailabilityPeriod.Create(start, end, Price, Id);
            if (availabilityPeriodResponse.IsSuccess)
            {
                AvailabilityPeriods.Add(availabilityPeriodResponse.Value);
            }
            return availabilityPeriodResponse;
        }
    }
}
