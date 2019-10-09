using ParcelDelivery.Domain.Entities;
using ParcelDelivery.Domain.Repositories;
using ParcelDelivery.Domain.ValueObjects;
using ParcelDelivery.Infrastructure.Repositories.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Infrastructure.Repositories
{
    public class DepartmentRepository : MongoRepository<Department>, IDepartmentRepository
    {

        public DepartmentRepository(string connectionString, string databaseName) : base(connectionString, databaseName)
        {
            //// Setup fake departments
            //_collection = new List<Department>
            //{
            //    CreateFakeDepartment(name: "Mail", weightMax: 1),
            //    CreateFakeDepartment(name: "Regular", weightMin: 1, weightMax: 10),
            //    CreateFakeDepartment(name: "Heavy", weightMin: 10),
            //    CreateFakeDepartment(name: "Insurance", valueMin: 1000)
            //};

        }

        private Department CreateFakeDepartment(string name, decimal? weightMin = null, decimal? weightMax = null, decimal? valueMin = null, decimal? valueMax = null)
        {
            Department department = new Department(name);

            if (weightMin.HasValue || weightMax.HasValue)
                department.WeightCriteria = new Interval(weightMin, weightMax);

            if (valueMin.HasValue || valueMax.HasValue)
                department.ValueCriteria = new Interval(valueMin, valueMax);

            return department;
        }

    }
}
