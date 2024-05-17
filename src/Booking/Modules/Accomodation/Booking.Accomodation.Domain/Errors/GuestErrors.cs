using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Domain.Errors
{
    public class GuestErrors
    {
        public static readonly Error FutureOrReservationInProgressExists = new("Guest.ReservationExists", "Unable to delete user, because future or reservation in progress exists");

        public static readonly Error GuestNotExist = new Error("Guest.NotExist", "Guest with provided id not exist");
    }
}
