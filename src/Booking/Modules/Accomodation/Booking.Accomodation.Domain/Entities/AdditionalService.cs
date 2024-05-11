using Booking.BuildingBlocks.Domain;

namespace Booking.AccommodationNS.Domain.Entities
{
    public class AdditionalService : Entity<Guid>, IStaticEntity
    {
        public string Name { get; private set; }

        private AdditionalService() { }

        private AdditionalService(Guid id, string name) { Id = id; Name = name; }
        public static AdditionalService Create(Guid id, string name)
        {
            return new AdditionalService(id, name);
        }
    }
}
