using System.Text.Json.Serialization;

namespace Booking.Accomodation.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReservationStatus
    {
        Waiting = 0,
        Accepted = 1,
        Canceled = 2,
    }
}
