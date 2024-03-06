using Microsoft.EntityFrameworkCore;


namespace Booking.UserAccess.Infrastructure.Database
{
    public class UserAccessDbContext : DbContext
    {
        public UserAccessDbContext(DbContextOptions<UserAccessDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("user_access");

            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

        }


    }
}
