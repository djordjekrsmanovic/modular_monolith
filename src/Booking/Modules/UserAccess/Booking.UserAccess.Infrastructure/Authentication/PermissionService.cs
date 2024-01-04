using Booking.UserAccess.Domain.Entities;
using Booking.UserAccess.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.UserAccess.Infrastructure.Authentication
{
    public class PermissionService : IPermissionService
    {

        private readonly UserAccessDbContext _context;
        
        public PermissionService(UserAccessDbContext context) {  _context = context; }
        public async Task<HashSet<string>> GetPermissionsAsync(Guid userId)
        {
            IReadOnlyCollection<Role>[] roles=await _context.Set<User>()
                .Include(x => x.Roles)
                .ThenInclude(x => x.Permissions)
                .Where(x => x.Id == userId)
                .Select(x => x.Roles)
                .ToArrayAsync();

            return roles
                .SelectMany(x => x)
                .SelectMany(x => x.Permissions)
                .Select(x => x.Name)
                .ToHashSet();
        }
    }
}
