using System.Text.Json.Serialization;

namespace Booking.Commerce.Domain.Enums
{


    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentMethod
    {
        Cash = 0,
        CreditCard = 1,
        PayPal = 2,
        BankTransfer = 3
    }
}
