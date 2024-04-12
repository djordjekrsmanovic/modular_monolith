﻿namespace Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects
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

        private Address(string street, string city, string country)
        {
            Street = street;
            City = city;
            Country = country;
        }

        public static Address CreateEmptyAdress()
        {
            return new Address();
        }

        public static Result<Address> Create(string street, string city, string country)
        {
            Address address = new Address(street, city, country);
            return Result.Success(address);
        }

        public string ConvertToString()
        {
            return $"{Street}, {City}, {Country}";
        }
    }
}
