using Booking.Booking.Domain.Enums;
using Booking.BuildingBlocks.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Booking.Domain.ValueObjects
{
    [ComplexType]
    public class Money : ValueObject
    {
        public Currency Currency { get; private set; }

        public Double Ammount { get; private set; }

        public static explicit operator Double(Money money) => money.Ammount;

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

        public static Result<Money> Create(Currency currency, Double amount)
        {
            return new Money(currency, amount);
        }

        public string ConvertToString()
        {
            return $"{Ammount} {Currency.ToString()}";
        }
    }
}
