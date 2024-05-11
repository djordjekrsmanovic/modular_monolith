using Booking.AccommodationNS.Domain.Entities;

namespace Booking.Accomodation.Domain.Repositories
{
    public interface IHostRepository
    {
        void Add(Host host);
        Task<Host> GetByIdAsync(Guid id);
    }
}
