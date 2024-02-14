using Booking.Booking.Domain.Entities;

namespace Booking.Accomodation.Domain.Repositories
{
    public interface IHostRepository
    {
        Task Add(Host host);
    }
}
