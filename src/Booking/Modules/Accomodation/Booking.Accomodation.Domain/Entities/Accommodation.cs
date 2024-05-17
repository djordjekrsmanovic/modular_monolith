﻿using Booking.AccommodationNS.Domain.Errors;
using Booking.AccommodationNS.Domain.ValueObjects;
using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.AccommodationNS.Domain.Entities
{
    public class Accommodation : AgregateRoot<Guid>
    {

        public string Name { get; private set; }

        public string Description { get; private set; }

        public Address Address { get; private set; }

        public GuestCapacity Capacity { get; private set; }

        public bool IsBlocked { get; private set; }

        public List<AdditionalService> AdditionalServices { get; private set; } = new List<AdditionalService>();

        public Money PricePerGuest { get; private set; }

        public List<Reservation> Reservations { get; private set; } = new List<Reservation>();

        public List<AvailabilityPeriod> AvailabilityPeriods { get; private set; } = new List<AvailabilityPeriod>();

        public List<Image> Images { get; private set; }

        public Guid HostId { get; private set; }

        public Double Raiting { get; private set; }

        public bool ReservationApprovalRequired { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public bool IsDeleted { get; private set; }

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
            IsDeleted = false;
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
            bool availibilityPeriodsExists = AvailabilityPeriods.Where(x => x.Slot.IsSlotInProvidedRange(startDate, endDate)).ToList().Count != 0;
            if (Reservations.Count != 0)
            {
                currentReservationNotExist = Reservations.Where(x => x.Slot.IsDateInSlot(startDate) || x.Slot.IsDateInSlot(endDate)).ToList().Count == 0;
            }

            return availibilityPeriodsExists && currentReservationNotExist;
        }

        public Result<AvailabilityPeriod> AddAvailabilityPeriod(DateTime start, DateTime end, Money price)
        {
            return addAvailabilityPeriod(start, end, price);
        }

        private Result<AvailabilityPeriod> addAvailabilityPeriod(DateTime start, DateTime end, Money price)
        {
            bool isOverlappingWithExistingPeriod = AvailabilityPeriods.Where(x => x.Slot.IsDateInSlot(start) || x.Slot.IsDateInSlot(end)).Any();
            if (isOverlappingWithExistingPeriod)
            {
                return Result.Failure<AvailabilityPeriod>(AvailabilityPeriodErrors.AvailaibilityPerodOverlapsWithExisting);
            }
            var availabilityPeriodResponse = AvailabilityPeriod.Create(start, end, price, Id);
            if (availabilityPeriodResponse.IsSuccess)
            {
                AvailabilityPeriods.Add(availabilityPeriodResponse.Value);
            }
            return availabilityPeriodResponse;
        }

        public Result<AvailabilityPeriod> AddAvailabilityPeriod(DateTime start, DateTime end, Money price, DateTime subscriptionRestriction)
        {
            if (end > subscriptionRestriction)
            {
                return Result.Failure<AvailabilityPeriod>(AvailabilityPeriodErrors.EndDateAfterSubscriptionExpiration);
            }

            return addAvailabilityPeriod(start, end, price);
        }

        public Result RemoveAvailabilityPeriod(Guid availabilityPeriodId)
        {
            AvailabilityPeriod period = AvailabilityPeriods.Where(x => x.Id == availabilityPeriodId).FirstOrDefault();
            Reservation reservation = Reservations.Where(x => period.Slot.IsDateInSlot(x.Slot.Start) || period.Slot.IsDateInSlot(x.Slot.End)).FirstOrDefault();
            if (reservation is not null)
            {
                return Result.Failure(AvailabilityPeriodErrors.AvailabilityPeriodContainsReservations);
            }
            AvailabilityPeriods.Remove(period);
            return Result.Success();
        }

        public Result<Guid> UpdateAccommodation(string name, string description,
            Money pricePerGuest, GuestCapacity capacity, List<Image> images, Address address,
            List<AdditionalService> additionalServices, bool reservationApprovalRequired)
        {
            Name = name;
            Description = description;
            PricePerGuest = pricePerGuest;
            Capacity = capacity;
            Address = address;
            return Id;
        }

        public void AddImages(List<Image> images)
        {
            Images.AddRange(images);
        }

        public Result<Reservation> AddReservation(DateTimeSlot slot, int guestNumber, Guid guestId, Guid? reservationRequestId)
        {
            if (!IsAvailableForBooking(slot.Start, slot.End))
            {
                return Result.Failure<Reservation>(AccommodationErrors.ReservationWithSameDateAlreadyExist);
            }

            var reservationResponse = Reservation.Create(slot, guestNumber, AvailabilityPeriods.Where(x => x.Slot.IsDateInSlot(slot.Start)).FirstOrDefault().Price, guestId, Id, reservationRequestId);
            if (reservationResponse.IsFailure)
            {
                return Result.Failure<Reservation>(reservationResponse.Error);
            }
            Reservations.Add(reservationResponse.Value);
            //throw domain event to delete all waiting reservation requests in current time slot
            return Result.Success(reservationResponse.Value);
        }

        public Result CancelReservation(Guid reservationId)
        {
            Reservation reservation = Reservations.Where(x => x.Id == reservationId).FirstOrDefault();

            if (reservation is null)
            {
                return Result.Failure(ReservationErrors.ReservationNotExist);
            }

            if (!reservation.IsPossibleToCancel())
            {
                return Result.Failure(ReservationErrors.UnableToCancelInProgressReservation);
            }

            Reservations.Remove(reservation);

            return Result.Success();
        }

        public void RecalculateRating(List<Review> reviews)
        {
            double sum = reviews.Sum(x => x.Rating);
            Raiting = sum / reviews.Count();
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public bool IsPosibleToDelete()
        {
            return !Reservations.Where(x => x.Slot.IsDateInSlot(DateTime.UtcNow) || x.Slot.IsDateBeforeSlot(DateTime.UtcNow)).Any();
        }

        public void CancelReservationRequests(DateTimeSlot reservationTimeSlot)
        {
            throw new NotImplementedException();
        }
    }
}
