using ParcelDelivery.Domain.Entities;
using ParcelDelivery.Domain.ValueObjects;
using ParcelDelivery.Services.Handler;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParcelDelivery.Tests.Services.Handler
{
    public class ParcelHandlerServiceTest
    {
        private ICollection<Department> _departments;
        private ICollection<Department> _wrongDepartments;


        public ParcelHandlerServiceTest()
        {
            // Setup departments
            _departments = new List<Department>();
            _departments.Add(CreateFakeDepartment(name: "Mail", weightMax: 1));
            _departments.Add(CreateFakeDepartment(name: "Regular", weightMin: 1, weightMax: 10));
            _departments.Add(CreateFakeDepartment(name: "Heavy", weightMin: 10));
            _departments.Add(CreateFakeDepartment(name: "Insurance up to 10kg", weightMax: 10, valueMin: 1000));
            _departments.Add(CreateFakeDepartment(name: "Insurance", valueMin: 1000));

            _wrongDepartments = new List<Department>();
            _wrongDepartments.Add(CreateFakeDepartment(name: "Mail", weightMax: 1));
            _wrongDepartments.Add(CreateFakeDepartment(name: "Regular", weightMin: 1, weightMax: 10));
            _wrongDepartments.Add(CreateFakeDepartment(name: "Regular", weightMin: 1, weightMax: 5));
            _wrongDepartments.Add(CreateFakeDepartment(name: "Heavy", weightMin: 10));
            _wrongDepartments.Add(CreateFakeDepartment(name: "Insurance", valueMin: 1000));
        }

        [Fact]
        public void Should_Handle_Based_Only_On_Max_Weight()
        {
            var parcelToHandle = CreateFakeParcel(weight: 0.02m,
                                                  value: 0);

            ParcelHandlerService handlerService = new ParcelHandlerService();
            Department department = handlerService.HandleParcelToDepartment(_departments,
                                                                            parcelToHandle);

            Assert.Equal("Mail", department.Name);
        }
        [Fact]
        public void Should_Handle_Based_Only_On_Min_Weight()
        {
            var parcelToHandle = CreateFakeParcel(weight: 15,
                                                  value: 0);

            ParcelHandlerService handlerService = new ParcelHandlerService();
            Department department = handlerService.HandleParcelToDepartment(_departments,
                                                                            parcelToHandle);

            Assert.Equal("Heavy", department.Name);
        }

        [Fact]
        public void Should_Handle_Based_On_Weight_Range()
        {
            var parcelToHandle = CreateFakeParcel(weight: 5,
                                                  value: 0);

            ParcelHandlerService handlerService = new ParcelHandlerService();
            Department department = handlerService.HandleParcelToDepartment(_departments,
                                                                            parcelToHandle);

            Assert.Equal("Regular", department.Name);
        }


        [Fact]
        public void Should_Handle_First_Based_On_Value_Instead_Of_Weight()
        {
            var parcelToHandle = CreateFakeParcel(weight: 5,
                                                  value: 2000);

            ParcelHandlerService handlerService = new ParcelHandlerService();
            Department department = handlerService.HandleParcelToDepartment(_departments, parcelToHandle);

            Assert.Equal("Insurance up to 10kg", department.Name);
        }

        [Fact]
        public void Should_Throw_Exception_On_More_Than_One_Department_Was_Found()
        {
            var parcelToHandle = CreateFakeParcel(weight: 2,
                                                  value: 0);

            ParcelHandlerService handlerService = new ParcelHandlerService();
            Action act = () => handlerService.HandleParcelToDepartment(_wrongDepartments,
                                                                       parcelToHandle);

            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void Should_Return_Null_When_No_Department_Was_Found()
        {
            Parcel parcelToHandle = CreateFakeParcel(weight: 0,
                                                     value: 0);

            List<Department> blankDepartments = new List<Department>();

            ParcelHandlerService handlerService = new ParcelHandlerService();
            Department department = handlerService.HandleParcelToDepartment(blankDepartments,
                                                                            parcelToHandle);

            Assert.Null(department);
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

        private Parcel CreateFakeParcel(decimal weight, decimal value)
        {
            return new Parcel(sender: new Person("Name"),
                              receipient: new Person("Name"),
                              weight: weight,
                              value: value);
        }

    }
}
