using Booking.Commerce.Domain.Entities;

namespace Booking.Commerce.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task Add(Reservation reservation);

        public Task<Reservation> Get(Guid id);
    }
}
