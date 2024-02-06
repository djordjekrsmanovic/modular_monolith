using Booking.BuildingBlocks.Domain;

namespace Booking.Commerce.Domain.Entities
{
    public class Payer : Entity<Guid>
    {
        public List<ReservationInvoice> Invoices { get; set; }
    }
}
