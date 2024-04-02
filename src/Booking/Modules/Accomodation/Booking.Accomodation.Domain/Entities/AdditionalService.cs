using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.Entities
{
    public class AdditionalService : Entity<Guid>
    {
        public string Name { get; set; }

        public static AdditionalService Create(Guid id, string name)
        {
            return new AdditionalService();
        }
    }
}
