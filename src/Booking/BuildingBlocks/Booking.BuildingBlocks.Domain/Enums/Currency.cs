using System.Text.Json.Serialization;

namespace Booking.BuildingBlocks.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Currency
    {
        USD,
        EUR,
        RSD
    }
}
