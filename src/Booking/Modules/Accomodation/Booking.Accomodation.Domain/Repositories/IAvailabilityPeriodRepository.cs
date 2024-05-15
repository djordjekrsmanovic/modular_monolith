using Booking.AccommodationNS.Domain.Entities;

namespace Booking.AccommodationNS.Domain.Repositories
{
    public interface IAvailabilityPeriodRepository
    {
        Task Add(AvailabilityPeriod period);
    }
}
