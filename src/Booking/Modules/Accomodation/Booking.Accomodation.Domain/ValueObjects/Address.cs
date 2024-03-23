﻿using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string City { get; private set; }

        public string Country { get; private set; }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return Country;

        }

        private Address()
        {
            Street = "";
            City = "";
            Country = "";
        }

        public static Address CreateEmptyAdress()
        {
            return new Address();
        }
    }
}
