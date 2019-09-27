using ParcelDelivery.Domain.Entities;
using ParcelDelivery.Domain.Repositories;
using ParcelDelivery.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDelivery.Services.Entities
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;

        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _repository.GetAll();
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Department GetDepartmentById(string id)
        {
            return _repository.Get(id);
        }

        public async Task<Department> GetDepartmentByIdAsync(string id)
        {
            return await _repository.GetAsync(id);
        }

        public void AddDepartment(Department department)
        {
            _repository.Add(department);
        }

        public async Task AddDepartmentAsync(Department department)
        {
            await _repository.AddAsync(department);
        }

        public void DeleteDepartment(Department department)
        {
            _repository.Delete(department);
        }

        public async Task DeleteDepartmentAsync(Department department)
        {
            await _repository.DeleteAsync(department);
        }

        public void UpdateDepartment(Department department)
        {
            _repository.Update(department);
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            await _repository.UpdateAsync(department);
        }
    }
}
