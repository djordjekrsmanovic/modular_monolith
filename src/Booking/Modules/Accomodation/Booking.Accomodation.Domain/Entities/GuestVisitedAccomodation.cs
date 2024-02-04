namespace Booking.Accomodation.Domain.Entities
{
    public class GuestVisitedAccomodation
    {
        public Guid GuestId { get; set; }

        public Guid AccomodationId { get; set; }
    }
}
