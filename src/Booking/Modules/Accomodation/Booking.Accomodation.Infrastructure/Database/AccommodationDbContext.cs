using Microsoft.EntityFrameworkCore;

namespace Booking.AccommodationNS.Infrastructure.Database
{
    public class AccommodationDbContext : DbContext
    {
        public AccommodationDbContext(DbContextOptions<AccommodationDbContext> options) : base(options) { Console.WriteLine("Constructred"); }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("accomodaton");

            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

        }
    }
}
