using Booking.Booking.Domain.Entities;

namespace Booking.Accomodation.Domain.Repositories
{
    public interface IAdditionalServiceRepository
    {
        Task<List<AdditionalService>> GetAsync();
    }
}
