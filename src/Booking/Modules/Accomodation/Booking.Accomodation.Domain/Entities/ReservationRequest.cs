using Booking.AccommodationNS.Domain.Enums;
using Booking.Accomodation.Domain.Errors;
using Booking.Accomodation.Domain.Events;
using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.AccommodationNS.Domain.Entities
{
    public class ReservationRequest : Entity<Guid>
    {
        public DateTimeSlot Slot { get; private set; }

        public ReservationRequestStatus Status { get; private set; }

        public int GuestNumber { get; private set; }

        public string? Message { get; private set; }

        public Guid GuestId { get; private set; }

        public Guid AccomodationId { get; private set; }

        public Guid HostId { get; private set; }

        public Money Price { get; private set; }

        private ReservationRequest(DateTimeSlot slot, int guestNumber, string message, Guid guestId, Guid accommodationId, Money price, Guid hostId)
        {
            Id = Guid.NewGuid();
            Slot = slot;
            GuestNumber = guestNumber;
            Message = message;
            GuestId = guestId;
            AccomodationId = accommodationId;
            Status = ReservationRequestStatus.Waiting;
            Price = price;
            HostId = hostId;
        }

        private ReservationRequest() { }


        public static Result<ReservationRequest> Create(DateTimeSlot slot, int guestNumber, string message, Guid guestId, Guid accommodationId, Money pricePerGuest, Guid hostId)
        {

            return Result.Success(new ReservationRequest(slot, guestNumber, message, guestId, accommodationId, Money.CalculateSumPriceForReservation(pricePerGuest, guestNumber, slot.GetNumberOfDays()), hostId));
        }

        public Result Accept()
        {
            if (Status == ReservationRequestStatus.Canceled)
            {
                return Result.Failure(ReservationRequestErrors.ReservationRequestAlreadyCanceled);
            }

            if (Status == ReservationRequestStatus.Accepted)
            {
                return Result.Failure(ReservationRequestErrors.ReservationRequestIsAlreadyAccepted);
            }

            Status = ReservationRequestStatus.Accepted;
            //throw domain event to create reservation from request
            RaiseDomainEvent(new ReservationRequestAcceptedDomainEvent(Slot, AccomodationId, GuestId, Id, GuestNumber));
            return Result.Success();
        }

        public Result Cancel()
        {
            if (Status == ReservationRequestStatus.Canceled)
            {
                return Result.Failure(ReservationRequestErrors.ReservationRequestAlreadyCanceled);
            }

            if (Status == ReservationRequestStatus.Accepted)
            {
                return Result.Failure(ReservationRequestErrors.ReservationRequestIsAlreadyAccepted);
            }

            Status = ReservationRequestStatus.Canceled;
            return Result.Success();
        }
    }
}
