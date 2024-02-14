using Booking.UserAccess.Domain.Entities;

namespace Booking.UserAccess.Domain.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default);
    }
}
