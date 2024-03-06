using Booking.BuildingBlocks.Domain;

namespace Booking.Commerce.Domain.Entities
{
    public class Payer : Entity<Guid>
    {
        public Guid PayerId { get; set; }
        public List<ReservationInvoice> Invoices { get; set; }

        private Payer(Guid id)
        {
            Id = Guid.NewGuid();
            PayerId = id;
            Invoices = new List<ReservationInvoice>();
        }

        public static Payer Create(Guid guestId)
        {
            return new Payer(guestId);
        }
    }
}
