using ParcelDelivery.Domain.Entities;
using ParcelDelivery.Domain.Repositories;
using ParcelDelivery.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
