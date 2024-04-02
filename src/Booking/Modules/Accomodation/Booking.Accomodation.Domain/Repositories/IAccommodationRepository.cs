using Booking.Booking.Domain.Entities;

namespace Booking.Accomodation.Domain.Repositories
{
    public interface IAccommodationRepository
    {
        Task Add(Accommodation accommodation);
    }
}
