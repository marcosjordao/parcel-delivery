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

    }
}
