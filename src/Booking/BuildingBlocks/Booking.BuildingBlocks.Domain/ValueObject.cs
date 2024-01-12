namespace Booking.BuildingBlocks.Domain
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetAtomicValues();
        public bool Equals(ValueObject? other)
        {
            return other is not null && ValuesAreEqual(other);
        }

        public override bool Equals(object? obj)
        {
            return obj is ValueObject other && Equals(other);
        }

        public override int GetHashCode()
        {
            return GetAtomicValues().Aggregate(default(int), HashCode.Combine);
        }

        private bool ValuesAreEqual(ValueObject other)
        {
            return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
        }

        public static bool operator ==(ValueObject? a, ValueObject? b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject? a, ValueObject? b) => !(a == b);
    }
}
