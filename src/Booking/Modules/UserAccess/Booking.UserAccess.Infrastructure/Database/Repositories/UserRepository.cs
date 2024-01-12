using Booking.UserAccess.Domain.Entities;
using Booking.UserAccess.Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Booking.UserAccess.Infrastructure.Database.Repositories
{
    public sealed class UserRepository : IUserRepository
    {

        private readonly UserAccessDbContext _context;
        public UserRepository(UserAccessDbContext userAccessDbContext) 
        {
            _context = userAccessDbContext;
        }

        public async Task Add(User user)
        {
            _context.Add(user);
        }

        public async Task<User> GetByEmailAsync(string username, CancellationToken cancellationToken = default)
        {
            return await _context.Set<User>().
                Where(user => user.Email.Equals(username))
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default)
        {
            return !await _context.Set<User>().AnyAsync(user => user.Email == email, cancellationToken);
        }
    }
}
