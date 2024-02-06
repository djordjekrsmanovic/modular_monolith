using Microsoft.EntityFrameworkCore;

namespace Booking.Commerce.Infrastructure.Database
{
    public class CommerceDbContext : DbContext
    {
        public CommerceDbContext(DbContextOptions<CommerceDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("commerce");

            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

        }
    }
}
