using Booking.AccommodationNS.Domain.Entities;

namespace Booking.AccommodationNS.Domain.Repositories
{
    public interface IHostRepository
    {
        void Add(Host host);
        Task<Host> GetByIdAsync(Guid id);
    }
}
