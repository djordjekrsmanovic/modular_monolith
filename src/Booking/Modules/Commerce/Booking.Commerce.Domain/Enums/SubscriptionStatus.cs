using System.Text.Json.Serialization;

namespace Booking.Commerce.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SubscriptionStatus
    {
        Active,
        Expired,
        WaitingForApproval,
        Canceled
    }
}
