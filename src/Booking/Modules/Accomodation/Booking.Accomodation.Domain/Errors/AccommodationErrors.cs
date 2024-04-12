using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.Enums;

namespace Booking.Accomodation.Domain.Errors
{
    public class AccommodationErrors
    {
        public static readonly Error ImageIsCorrupted = new("Accommodation.ImageCorrupted", "Image is corrupted", ErrorType.BadRequest);

        public static readonly Error IdNotExist = new("Accommodation.NotExistingId", "Accommodation with provided id does not exist", ErrorType.BadRequest);
    }
}
