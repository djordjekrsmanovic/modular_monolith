using Booking.Booking.Domain.Entities;

namespace Booking.Accomodation.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task Add(Reservation reservation);
        Task<Reservation> GetAsync(Guid reservationId);
        public Task<List<Reservation>> GetGuestReservations(Guid guestId);
    }
}
