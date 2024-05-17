using Booking.AccommodationNS.Domain.Events;
using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.AccommodationNS.Domain.Entities
{
    public class Reservation : Entity<Guid>
    {
        public DateTimeSlot Slot { get; private set; }

        public int GuestNumber { get; private set; }

        public Money TotalPrice { get; private set; }

        public Guid GustId { get; private set; }

        public Guid AccommodationId { get; private set; }

        public Guid? ReservationRequestId { get; private set; }


        private Reservation(DateTimeSlot slot, int guestNumber, Money price, Guid gustId, Guid accomodationId, Guid? reservationRequestId)
        {
            Id = Guid.NewGuid();
            Slot = slot;
            GuestNumber = guestNumber;
            TotalPrice = price;
            GustId = gustId;
            AccommodationId = accomodationId;
            ReservationRequestId = reservationRequestId;
        }

        private Reservation() { }

        public static Result<Reservation> Create(DateTimeSlot slot, int guestNumber, Money pricePerGuest, Guid guestId, Guid accommodationId, Guid? reservationRequestId)
        {
            var reservation = new Reservation(slot, guestNumber, Money.CalculateSumPriceForReservation(pricePerGuest, guestNumber, slot.GetNumberOfDays()), guestId, accommodationId, reservationRequestId);
            reservation.RaiseDomainEvent(new ReservationCreatedDomainEvent(reservation.Id, reservation.TotalPrice, reservation.AccommodationId, reservation.Slot));
            return Result.Success(reservation);
        }

        public bool IsPossibleToCancel()
        {
            if (Slot.Start <= DateTime.UtcNow)
            {
                return false;
            }
            return true;
        }
    }
}
