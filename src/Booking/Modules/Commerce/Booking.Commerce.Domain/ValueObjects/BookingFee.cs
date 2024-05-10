using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Commerce.Domain.ValueObjects
{
    public class BookingFee
    {
        private const Double BookingFeeRate = 10.0;

        public Double BookingFeePercent { get; set; }

        public Money MoneyToKeepByPlatform { get; set; }

        private BookingFee() { }

        private BookingFee(Money totalPrice)
        {
            BookingFeePercent = BookingFeeRate;

            MoneyToKeepByPlatform = totalPrice.CalculatePercent(BookingFeePercent);
        }

        public static BookingFee Create(Money totalPrice)
        {
            return new BookingFee(totalPrice);
        }
    }
}
