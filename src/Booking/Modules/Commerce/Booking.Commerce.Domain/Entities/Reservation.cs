using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;
using Booking.Commerce.Domain.Enums;
using Booking.Commerce.Domain.Errors;

namespace Booking.Commerce.Domain.Entities
{
    public class Reservation : AgregateRoot<Guid>
    {
        public List<ReservationPayment> Payments { get; private set; }

        public Money Price { get; set; }

        private Reservation()
        {

        }

        private Reservation(Guid id, Money price)
        {
            Id = id;
            Payments = new List<ReservationPayment>();
            Price = price;
        }

        public static Result<Reservation> Create(Guid id, Money price)
        {
            return Result.Success(new Reservation(id, price));
        }

        public Result<ReservationPayment> Pay(PaymentMethod method, Guid payerId)
        {
            if (Payments.Where(x => x.Status == PaymentStatus.Confirmed || x.Status == PaymentStatus.InProgress).Any())
            {
                return Result.Failure<ReservationPayment>(ReservationErrors.ReservationAlreadyPaidOrInProgress);
            }

            return ReservationPayment.Create(Price, method, Id, payerId);
        }

        public Result<ReservationPayment> ConfirmPayment()
        {
            var payment = Payments.Where(x => x.Status == PaymentStatus.InProgress).FirstOrDefault();
            if (payment is null)
            {
                return Result.Failure<ReservationPayment>(ReservationErrors.ReservationPaymentNotExist);
            }

            return payment.Confirm();
        }

        public Result<ReservationPayment> CancelPayment()
        {
            var payment = Payments.Where(x => x.Status == PaymentStatus.InProgress).FirstOrDefault();
            if (payment is null)
            {
                return Result.Failure<ReservationPayment>(ReservationErrors.ReservationPaymentNotExist);
            }

            return payment.Cancel();
        }
    }
}
