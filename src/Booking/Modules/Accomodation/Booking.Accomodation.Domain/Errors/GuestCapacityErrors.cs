using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.Enums;

namespace Booking.AccommodationNS.Domain.Errors
{
    public class GuestCapacityErrors
    {
        public static readonly Error InvalidCapacityValues = new("GuestCapacity.UnvalidCapacityValues", "Capacity value must be positive number!", ErrorType.BadRequest);

        public static readonly Error WrongCapacityValues = new("GuestCapacity.WrongCapacityValues", "Min Guest number must be less or equal than Max Guest number!", ErrorType.BadRequest);
    }
}
