using Booking.Commerce.Domain.Entities;

namespace Booking.Commerce.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task Add(Reservation reservation);

        Task<Reservation> Get(Guid id);
    }
}
