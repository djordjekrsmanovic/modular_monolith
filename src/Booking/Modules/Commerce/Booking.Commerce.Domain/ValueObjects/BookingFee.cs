using Booking.BuildingBlocks.Domain.SharedKernel;

namespace Booking.Commerce.Domain.ValueObjects
{
    public class BookingFee
    {
        private const Double BookingFeeRate = 10.0;

        public Double BookingFeePercent { get; set; }

        public Money MoneyToKeepByPlatfomr { get; set; }

        private BookingFee() { }

        private BookingFee(Money totalPrice)
        {
            BookingFeePercent = BookingFeeRate;

            MoneyToKeepByPlatfomr = totalPrice.CalculatePercent(BookingFeePercent);
        }

        public static BookingFee Create(Money totalPrice)
        {
            return new BookingFee(totalPrice);
        }
    }
}
