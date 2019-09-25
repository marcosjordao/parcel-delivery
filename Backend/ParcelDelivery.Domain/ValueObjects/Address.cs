using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Domain.ValueObjects
{
    public class Address
    {

        private Address()
        {

        }

        public Address(string street, string houseNumber, string postalCode, string city)
        {
            Street = street;
            HouseNumber = houseNumber;
            PostalCode = postalCode;
            City = city;
        }

        public string Street { get; private set; }
        public string HouseNumber { get; private set; }
        public string PostalCode { get; private set; }
        public string City { get; private set; }
    }
}
