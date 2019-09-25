using ParcelDelivery.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Domain.Entities
{
    public class Department
    {
        public Department(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public Interval WeightCriteria { get; set; }
        public Interval ValueCriteria { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return Name.Equals(((Department) obj).Name);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
