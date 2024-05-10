using Booking.Booking.Domain.Entities;

namespace Booking.Accomodation.Domain.Repositories
{
    public interface IGuestRepository
    {
        Task Add(Guest guest);
        Task<Guest> GetAsync(Guid guestId);
    }
}
