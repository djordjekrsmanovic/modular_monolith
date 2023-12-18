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
        public Task<User> GetByEmailAsync(string username, CancellationToken cancellationToken = default)
        {
            return _context.Set<User>().
                Where(user => user.Email.Equals(username))
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
