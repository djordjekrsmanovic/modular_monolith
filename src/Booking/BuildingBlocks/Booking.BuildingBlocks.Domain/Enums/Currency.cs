namespace Booking.BuildingBlocks.Domain.Enums
{
    public enum Currency
    {
        USD,
        EUR,
        RSD
    }

    public static class CurrencyConverter
    {
        public static Currency ConvertStringToEnum(this Currency currency, string currencyValue)
        {
            switch (currencyValue)
            {
                case "USD": return Currency.USD;
                case "EUR": return Currency.EUR;
                case "RSD": return Currency.RSD;
                default: throw new InvalidOperationException();
            }
        }
    }
}



