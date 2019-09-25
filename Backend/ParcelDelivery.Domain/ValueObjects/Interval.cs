using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Domain.ValueObjects
{
    public class Interval
    {
        public Interval()
        {

        }

        public Interval(decimal? min, decimal? max)
        {
            Min = min;
            Max = max;
        }

        public decimal? Min { get; set; }
        public decimal? Max { get; set; }

        public bool IsInInterval(decimal value)
        {
            var min = Min ?? decimal.MinValue;
            var max = Max ?? decimal.MaxValue;

            return (value > min && value <= max);
        }
    }
}
