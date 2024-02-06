using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel;
using Booking.Commerce.Domain.ValueObjects;

namespace Booking.Commerce.Domain.Entities
{
    public class ReservationInvoice : Entity<Guid>
    {
        public Money Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public BookingFee BookingFee { get; set; }

        public Payment Payment { get; set; }

        public Guid ReservationId { get; set; }

    }
}
