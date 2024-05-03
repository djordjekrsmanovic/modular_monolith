using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;
using Booking.Commerce.Domain.Enums;
using Booking.Commerce.Domain.Errors;

namespace Booking.Commerce.Domain.Entities
{
    public class ReservationPayment : Entity<Guid>
    {
        public Money Amount { get; set; }

        public DateTime ExecutonTime { get; set; }

        public PaymentStatus Status { get; set; }

        public PaymentMethod Method { get; set; }

        public Guid ReservationId { get; set; }

        private ReservationPayment() { }

        private ReservationPayment(Money amount, DateTime executonTime, PaymentStatus status, PaymentMethod method, Guid reservationId)
        {
            Amount = amount;
            ExecutonTime = executonTime;
            Status = status;
            Method = method;
            ReservationId = reservationId;
        }

        public static Result<ReservationPayment> Create(Money amount, PaymentMethod method, Guid productId)
        {
            return Result.Success(new ReservationPayment(amount, DateTime.UtcNow, PaymentStatus.InProgress, method, productId));
        }

        public Result<ReservationPayment> Confirm()
        {
            if (Status != PaymentStatus.InProgress)
            {
                return Result.Failure<ReservationPayment>(ReservationErrors.ReservationPaymentInWrongState);
            }

            Status = PaymentStatus.Confirmed;
            // throw domain event to create invoice
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
