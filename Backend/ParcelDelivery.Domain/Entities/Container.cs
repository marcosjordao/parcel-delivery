using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ParcelDelivery.Domain.Entities
{
    public class Container
    {

        public Container(int id, DateTime shippingDate)
        {
            Id = id;
            ShippingDate = shippingDate;
            Parcels = new List<Parcel>();
        }

        public int Id { get; private set; }
        public DateTime ShippingDate { get; private set; }
        public ICollection<Parcel> Parcels { get; private set; }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return Id.Equals(((Container) obj).Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }
}
