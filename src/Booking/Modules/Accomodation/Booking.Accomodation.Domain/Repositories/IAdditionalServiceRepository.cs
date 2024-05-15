using Booking.AccommodationNS.Domain.Entities;

namespace Booking.AccommodationNS.Domain.Repositories
{
    public interface IAdditionalServiceRepository
    {
        Task<List<AdditionalService>> GetAsync();
    }
}
