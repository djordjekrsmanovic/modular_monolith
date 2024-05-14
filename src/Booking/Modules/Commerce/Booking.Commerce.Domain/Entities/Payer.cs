using Booking.BuildingBlocks.Domain;

namespace Booking.Commerce.Domain.Entities
{
    public class Payer : Entity<Guid>
    {

        public List<ReservationInvoice> Invoices { get; private set; }

        private Payer(Guid id)
        {
            Id = id;
            Invoices = new List<ReservationInvoice>();
        }

        private Payer() { }

        public static Payer Create(Guid id)
        {
            return new Payer(id);
        }

        public void AddInvoice(ReservationInvoice invoice)
        {
            Invoices.Add(invoice);
        }
    }
}
