using ParcelDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Domain.Services
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAllDepartments();
    }
}
