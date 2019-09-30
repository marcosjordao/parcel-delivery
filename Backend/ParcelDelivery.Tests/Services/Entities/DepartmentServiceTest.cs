﻿using Moq;
using ParcelDelivery.Domain.Entities;
using ParcelDelivery.Domain.Repositories;
using ParcelDelivery.Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParcelDelivery.Tests.Services.Entities
{
    public class DepartmentServiceTest
    {
        private readonly Mock<IDepartmentRepository> _repositoryMock;
        private readonly Mock<Department> _departmentMock;
        private readonly DepartmentService _service;

        public DepartmentServiceTest()
        {
            _repositoryMock = new Mock<IDepartmentRepository>();
            _departmentMock = new Mock<Department>();
            _service = new DepartmentService(_repositoryMock.Object);
        }

        [Fact]
        private void GetAllDepartments_ShouldInvokeRepository_AndReturnListOfDepartments ()
        {
            var expected = new List<Department>
            {
                new Department("test1"),
                new Department("test2")
            };

            _repositoryMock.Setup(x => x.GetAll()).Returns(expected);

            var result = _service.GetAllDepartments();

            _repositoryMock.Verify(x => x.GetAll(), Times.Once);
            Assert.Same(expected, result);
        }

        [Fact]
        private async Task GetAllDepartments_ShouldInvokeRepository_AndReturnListOfDepartments_Async()
        {
            var expected = new List<Department>
            {
                new Department("test1"),
                new Department("test2")
            };

            _repositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(expected);

            var result = await _service.GetAllDepartmentsAsync();

            _repositoryMock.Verify(x => x.GetAllAsync(), Times.Once);
            Assert.Same(expected, result);
        }

        [Fact]
        private void GetDepartmentById_ShouldInvokeRepository_AndReturnDepartment()
        {
            var expected = new Department("test1");
            _repositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(expected);

            var result = _service.GetDepartmentById(It.IsAny<string>());

            _repositoryMock.Verify(x => x.Get(It.IsAny<string>()), Times.Once);
            Assert.Same(expected, result);
        }

        [Fact]
        private async Task GetDepartmentById_ShouldInvokeRepository_AndReturnDepartment_Async()
        {
            var expected = new Department("test1");
            _repositoryMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(expected);

            var result = await _service.GetDepartmentByIdAsync(It.IsAny<string>());

            _repositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
            Assert.Same(expected, result);
        }

        [Fact]
        private void AddDepartment_ShouldInvokeRepository()
        {

            _service.AddDepartment(_departmentMock.Object);

            _repositoryMock.Verify(x => x.Add(_departmentMock.Object), Times.Once);
        }

        [Fact]
        private async Task AddDepartment_ShouldInvokeRepository_Async()
        {

            await _service.AddDepartmentAsync(_departmentMock.Object);

            _repositoryMock.Verify(x => x.AddAsync(_departmentMock.Object), Times.Once);
        }
        
        [Fact]
        private void UpdateDepartment_ShouldInvokeRepository()
        {

            _service.UpdateDepartment(_departmentMock.Object);

            _repositoryMock.Verify(x => x.Update(_departmentMock.Object), Times.Once);
        }

        [Fact]
        private async Task UpdateDepartment_ShouldInvokeRepository_Async()
        {

            await _service.UpdateDepartmentAsync(_departmentMock.Object);

            _repositoryMock.Verify(x => x.UpdateAsync(_departmentMock.Object), Times.Once);
        }

        [Fact]
        private void DeleteDepartment_ShouldInvokeRepository()
        {

            _service.DeleteDepartment(_departmentMock.Object);

            _repositoryMock.Verify(x => x.Delete(_departmentMock.Object), Times.Once);
        }

        [Fact]
        private async Task DeleteDepartment_ShouldInvokeRepository_Async()
        {

            await _service.DeleteDepartmentAsync(_departmentMock.Object);

            _repositoryMock.Verify(x => x.DeleteAsync(_departmentMock.Object), Times.Once);
        }
    }
}
