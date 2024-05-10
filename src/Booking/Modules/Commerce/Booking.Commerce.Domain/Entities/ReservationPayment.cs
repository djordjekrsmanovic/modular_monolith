using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;
using Booking.Commerce.Domain.Enums;
using Booking.Commerce.Domain.Errors;
using Booking.Commerce.Domain.Events;

namespace Booking.Commerce.Domain.Entities
{
    public class ReservationPayment : Entity<Guid>
    {
        public Money Amount { get; set; }

        public DateTime ExecutonTime { get; set; }

        public PaymentStatus Status { get; set; }

        public PaymentMethod Method { get; set; }

        public Guid ReservationId { get; set; }

        public Guid PayerId { get; set; }

        private ReservationPayment() { }

        private ReservationPayment(Money amount, DateTime executonTime, PaymentStatus status, PaymentMethod method, Guid reservationId, Guid payerId)
        {
            Amount = amount;
            ExecutonTime = executonTime;
            Status = status;
            Method = method;
            ReservationId = reservationId;
            PayerId = payerId;
        }

        public static Result<ReservationPayment> Create(Money amount, PaymentMethod method, Guid productId, Guid payerId)
        {
            return Result.Success(new ReservationPayment(amount, DateTime.UtcNow, PaymentStatus.InProgress, method, productId, payerId));
        }

        public Result<ReservationPayment> Confirm()
        {
            if (Status != PaymentStatus.InProgress)
            {
                return Result.Failure<ReservationPayment>(ReservationErrors.ReservationPaymentInWrongState);
            }

            Status = PaymentStatus.Confirmed;
            RaiseDomainEvent(new ReservationPaymentConfirmed(this));
            return this;
        }

        internal Result<ReservationPayment> Cancel()
        {
            if (Status != PaymentStatus.InProgress)
            {
                return Result.Failure<ReservationPayment>(ReservationErrors.ReservationPaymentInWrongState);
            }

            Status = PaymentStatus.Canceled;

            return this;
        }
    }
}
