using System.Text.Json.Serialization;

namespace Booking.Commerce.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentStatus
    {
        Confirmed,
        Canceled,
        InProgress,
    }
}
