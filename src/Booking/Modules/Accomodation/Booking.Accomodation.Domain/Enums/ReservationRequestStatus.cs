using System.Text.Json.Serialization;

namespace Booking.AccommodationNS.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReservationRequestStatus
    {
        Waiting = 0,
        Accepted = 1,
        Canceled = 2,
    }
}
