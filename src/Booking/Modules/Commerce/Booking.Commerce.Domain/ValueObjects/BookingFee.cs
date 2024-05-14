using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Commerce.Domain.ValueObjects
{
    public class BookingFee : ValueObject
    {
        private const Double BookingFeeRate = 10.0;

        public Double BookingFeePercent { get; private set; }

        public Money MoneyToKeepByPlatform { get; private set; }

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

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return BookingFeePercent;
            yield return MoneyToKeepByPlatform;
        }
    }
}
