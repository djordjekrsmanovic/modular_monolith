using Booking.UserAccess.Domain.Entities;
using Booking.UserAccess.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Booking.UserAccess.Infrastructure.Database.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {

        private readonly UserAccessDbContext _context;
        public UserRepository(UserAccessDbContext userAccessDbContext)
        {
            _context = userAccessDbContext;
        }

        public void Add(User user)
        {
            _context.Add(user);
        }

        public async Task<User> GetByEmailAsync(string username, CancellationToken cancellationToken = default)
        {
            return await _context.Set<User>().
                Where(user => user.Email.Equals(username))
                .Include(user => user.Roles)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Set<User>().Where(user => user.Id == id).Include(user => user.Roles).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default)
        {
            return !await _context.Set<User>().AnyAsync(user => user.Email == email, cancellationToken);
        }
    }
}
