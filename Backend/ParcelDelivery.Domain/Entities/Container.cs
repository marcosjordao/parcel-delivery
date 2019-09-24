using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Domain.Entities
{
    public class Container
    {
        public Container(int id, DateTime shippingDate)
        {
            Id = id;
            ShippingDate = shippingDate;
        }

        public int Id { get; private set; }
        public DateTime ShippingDate { get; private set; }
        public IEnumerable<Parcel> Parcels { get; private set; }

        
    }
}
