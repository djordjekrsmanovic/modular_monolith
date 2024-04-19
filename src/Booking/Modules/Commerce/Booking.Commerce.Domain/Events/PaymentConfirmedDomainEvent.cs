using Booking.BuildingBlocks.Domain;

namespace Booking.Commerce.Domain.Events
{
    public record PaymentConfirmedDomainEvent(DateTime Start, int DurationInMonths, int AccommodationLimit, Guid SubscriberId) : DomainEvent
    {
    }
}
