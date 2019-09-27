using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Domain.ValueObjects
{
    public class Interval
    {
        public Interval(decimal? min = null, decimal? max = null)
        {
            Min = min;
            Max = max;
        }

        public decimal? Min { get; set; }
        public decimal? Max { get; set; }

        public bool IsEmpty()
        {
            return (Min == null && Max == null);
        }
        public bool IsInInterval(decimal value)
        {
            if (Min != null & Max != null)
                return (value > Min && value <= Max);
            else if (Min != null)
                return value > Min;
            else
                return value <= Max;
        }
    }
}
