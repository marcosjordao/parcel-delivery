using ParcelDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Domain.Services
{
    public interface IParcelHandlerService
    {
        Department HandleParcelToDepartment(ICollection<Department> departments, Parcel parcel);
    }
}
