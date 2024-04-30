using System.Text.Json.Serialization;

namespace Booking.Booking.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReservationRequestStatus
    {
        Waiting = 0,
        Accepted = 1,
        Canceled = 2,
    }
}
