using Booking.Booking.Domain.Entities;

namespace Booking.Accomodation.Domain.Repositories
{
    public interface IAvailabilityPeriodRepository
    {
        Task Add(AvailabilityPeriod period);
    }
}
