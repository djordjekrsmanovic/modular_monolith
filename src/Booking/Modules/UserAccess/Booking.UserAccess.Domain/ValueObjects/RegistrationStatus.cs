using Booking.BuildingBlocks.Domain;

namespace Booking.UserAccess.Domain.ValueObjects
{
    public class RegistrationStatus : ValueObject, IStaticEntity
    {
        private RegistrationStatus() { }

        private RegistrationStatus(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public static RegistrationStatus Confirmed => new RegistrationStatus(nameof(Confirmed));

        public static RegistrationStatus Rejected => new RegistrationStatus(nameof(Rejected));

        public static RegistrationStatus Expired => new RegistrationStatus(nameof(Expired));

        public static RegistrationStatus Waiting => new RegistrationStatus(nameof(Waiting));
    }
}
