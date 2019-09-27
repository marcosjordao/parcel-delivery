using ParcelDelivery.Domain.Entities;
using ParcelDelivery.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParcelDelivery.Services.Handler
{
    public class ParcelHandlerService: IParcelHandlerService
    {

        public Department HandleParcelToDepartment(IEnumerable<Department> departments, Parcel parcel)
        {
            // 1) Filter by Value and Weight
            var filteredByValueAndWeight = departments.Where(f => f.ValueCriteria != null && !f.ValueCriteria.IsEmpty() &&
                                                                  f.ValueCriteria.IsInInterval(parcel.Value) &&
                                                                  f.WeightCriteria != null && !f.WeightCriteria.IsEmpty() &&
                                                                  f.WeightCriteria.IsInInterval(parcel.Weight));
            // Return if one was found
            if (filteredByValueAndWeight.Count() == 1)
                return filteredByValueAndWeight.First();

            // Exception if more than one was found
            else if (filteredByValueAndWeight.Count() > 1)
                throw new InvalidOperationException("Cannot handle Parcel to a specific Department because more than one accepts it.");


            // 2) Filter only by Value
            var filteredByValue = departments.Where(f => f.ValueCriteria != null && !f.ValueCriteria.IsEmpty() &&
                                                         f.ValueCriteria.IsInInterval(parcel.Value) &&
                                                         (f.WeightCriteria == null || f.WeightCriteria.IsEmpty()));

            // Return if one was found
            if (filteredByValue.Count() == 1)
                return filteredByValue.First();

            // Exception if more than one was found
            else if (filteredByValue.Count() > 1)
                throw new InvalidOperationException("Cannot handle Parcel to a specific Department because more than one accepts it.");


            // 3) Filter only by Weight
            var filteredByWeight = departments.Where(f => f.WeightCriteria != null && !f.WeightCriteria.IsEmpty() &&
                                                          f.WeightCriteria.IsInInterval(parcel.Weight) &&
                                                          (f.ValueCriteria == null || f.ValueCriteria.IsEmpty())).ToList();

            // Return if one was found
            if (filteredByWeight.Count() == 1)
                return filteredByWeight.First();

            // Exception if more than one was found
            else if (filteredByWeight.Count() > 1)
                throw new InvalidOperationException("Cannot handle Parcel to a specific Department because more than one accepts it.");

            return null;
        }
    }
}
