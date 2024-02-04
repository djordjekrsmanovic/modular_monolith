namespace Booking.Accomodation.Domain.Entities
{
    public class GuestFavouriteAccomodation
    {
        public Guid GuestId { get; set; }

        public Guid AccomodationId { get; set; }
    }
}
