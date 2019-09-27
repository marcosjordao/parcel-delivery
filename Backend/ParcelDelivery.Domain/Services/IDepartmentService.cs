using ParcelDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDelivery.Domain.Services
{
    public interface IDepartmentService
    {
        Department GetDepartmentById(string id);
        Task<Department> GetDepartmentByIdAsync(string id);

        IEnumerable<Department> GetAllDepartments();
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();

        void AddDepartment(Department department);
        Task AddDepartmentAsync(Department department);

        void UpdateDepartment(Department department);
        Task UpdateDepartmentAsync(Department department);

        void DeleteDepartment(Department department);
        Task DeleteDepartmentAsync(Department department);
    }
}
