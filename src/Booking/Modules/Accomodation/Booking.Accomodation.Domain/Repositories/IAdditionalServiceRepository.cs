using Booking.AccommodationNS.Domain.Entities;

namespace Booking.Accomodation.Domain.Repositories
{
    public interface IAdditionalServiceRepository
    {
        Task<List<AdditionalService>> GetAsync();
    }
}
