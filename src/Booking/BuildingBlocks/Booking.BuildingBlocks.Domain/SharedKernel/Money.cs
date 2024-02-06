using Booking.BuildingBlocks.Domain.Enums;

namespace Booking.BuildingBlocks.Domain.SharedKernel
{
    public class Money : ValueObject
    {
        public Currency Currency { get; }

        public Double Ammount { get; }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Currency;
            yield return Ammount;
        }

        private Money() { }

        private Money(Currency currency, Double amount)
        {
            Currency = currency;
            Ammount = amount;
        }

        public Money Add(Money other)
        {
            if (Currency == other.Currency)
            {
                throw new InvalidOperationException("Unable to add amount of differenc currency!");
            }
            return new Money(Currency, Ammount + other.Ammount);
        }

        public Money Substract(Money other)
        {
            if (Currency == other.Currency)
            {
                throw new InvalidOperationException("Unable to add amount of differenc currency!");
            }
            return new Money(Currency, Ammount - other.Ammount);
        }

        public Money CalculatePercent(Double percent)
        {
            return new Money(Currency, (Ammount * percent) / 100);
        }

        public static Money CreateMoney(Currency currency, Double amount)
        {
            return new Money(currency, amount);
        }
    }
}
