using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Domain.Entities
{
    public class Parcel
    {
        private Parcel()
        {

        }
        public Parcel(Person sender, Person receipient, decimal weight, decimal value)
        {
            Sender = sender;
            Receipient = receipient;
            Weight = weight;
            Value = value;
        }

        public Person Sender { get; private set; }
        public Person Receipient { get; private set; }
        public decimal Weight { get; private set; }
        public decimal Value { get; private set; }
    }
}
