using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;
using Booking.Commerce.Domain.ValueObjects;

namespace Booking.Commerce.Domain.Entities
{
    public class ReservationInvoice : Entity<Guid>
    {
        public Money SumPrice { get; set; }

        public DateTime CreatedAt { get; set; }

        public BookingFee BookingFee { get; set; }

        public ReservationPayment Payment { get; set; }

        private ReservationInvoice() { }

        private ReservationInvoice(Money sumPrice, BookingFee bookingFee, ReservationPayment payment)
        {
            SumPrice = sumPrice;
            CreatedAt = DateTime.UtcNow;
            BookingFee = bookingFee;
            Payment = payment;
        }

        public static Result<ReservationInvoice> Create(ReservationPayment payment)
        {
            BookingFee fee = BookingFee.Create(payment.Amount);
            Money sumPrice = payment.Amount.Substract(fee.MoneyToKeepByPlatform);
            return Result.Success(new ReservationInvoice(sumPrice, fee, payment));
        }

    }
}
