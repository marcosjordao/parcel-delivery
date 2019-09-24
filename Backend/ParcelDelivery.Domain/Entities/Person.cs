using ParcelDelivery.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Domain.Entities
{
    public class Person
    {
        public Person(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; private set; }
        public Address Address { get; private set; }
    }
}
