using Booking.BuildingBlocks.Domain;

namespace Booking.Commerce.Domain.Entities
{
    public class Payer : Entity<Guid>
    {
        public List<ReservationInvoice> Invoices { get; set; }

        private Payer(Guid id)
        {
            Id = id;
            Invoices = new List<ReservationInvoice>();
        }

        public static Payer Create(Guid gustId)
        {
            return new Payer(gustId);
        }
    }
}
