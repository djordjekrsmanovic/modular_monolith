using Microsoft.EntityFrameworkCore;

namespace Booking.AccommodationNS.Infrastructure.Database
{
    public class AccomodationDbContext : DbContext
    {
        public AccomodationDbContext(DbContextOptions<AccomodationDbContext> options) : base(options) { Console.WriteLine("Constructred"); }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("accomodaton");

            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

        }
    }
}
