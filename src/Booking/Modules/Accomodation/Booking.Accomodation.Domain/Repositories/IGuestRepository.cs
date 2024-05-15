using Booking.AccommodationNS.Domain.Entities;

namespace Booking.AccommodationNS.Domain.Repositories
{
    public interface IGuestRepository
    {
        Task Add(Guest guest);
        Task<Guest> GetAsync(Guid guestId);
    }
}
