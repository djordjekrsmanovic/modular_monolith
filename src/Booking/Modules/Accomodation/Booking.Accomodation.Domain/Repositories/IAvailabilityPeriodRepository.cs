using Booking.AccommodationNS.Domain.Entities;

namespace Booking.Accomodation.Domain.Repositories
{
    public interface IAvailabilityPeriodRepository
    {
        Task Add(AvailabilityPeriod period);
    }
}
