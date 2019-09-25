using ParcelDelivery.Domain.Entities;
using ParcelDelivery.Domain.ValueObjects;
using ParcelDelivery.Services.Handler;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ParcelDelivery.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup departments
            var _departments = new List<Department>();
            _departments.Add(CreateFakeDepartment(name: "Mail_1", valueMin: 1, valueMax: 10));
            _departments.Add(CreateFakeDepartment(name: "Mail_2", valueMin: 5, valueMax: 20));
            //_departments.Add(CreateFakeDepartment(name: "Mail", weightMax: 1));
            //_departments.Add(CreateFakeDepartment(name: "Regular", weightMin: 1, weightMax: 10));
            //_departments.Add(CreateFakeDepartment(name: "Heavy", weightMin: 10));
            //_departments.Add(CreateFakeDepartment(name: "Insurance up to 10kg", weightMax: 10, valueMin: 1000));
            //_departments.Add(CreateFakeDepartment(name: "Insurance up to 20kg", weightMin: 10, weightMax:20, valueMin: 1000));
            //_departments.Add(CreateFakeDepartment(name: "Insurance", valueMin: 1000));

            var parcelToHandle = CreateFakeParcel(weight: 0,
                                                  value: 6);

            ParcelHandlerService handlerService = new ParcelHandlerService();
            Department department = handlerService.HandleParcelToDepartment(_departments,
                                                                            parcelToHandle);
            Debug.Print(department.Name);
        }


        private static Parcel CreateFakeParcel(decimal weight, decimal value)
        {
            return new Parcel(sender: new Person("Name", new Address("Street", "1", "2", "City")),
                              receipient: new Person("Name", new Address("Street", "1", "2", "City")),
                              weight: weight,
                              value: value);
        }

        private static Department CreateFakeDepartment(string name, decimal? weightMin = null, decimal? weightMax = null, decimal? valueMin = null, decimal? valueMax = null)
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
