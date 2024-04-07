using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.Entities
{
    public class AdditionalService : Entity<Guid>, IStaticEntity
    {
        public string Name { get; set; }

        private AdditionalService() { }

        private AdditionalService(Guid id, string name) { Id = id; Name = name; }
        public static AdditionalService Create(Guid id, string name)
        {
            return new AdditionalService(id, name);
        }
    }
}
