using ParcelDelivery.Domain.Entities;
using ParcelDelivery.Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ParcelDelivery.UnitTests.Services.Validators
{
    public class DepartmentValidatorTest
    {
        const string VALID_NAME = "Department Name";

        [Fact]
        public void Name_ShouldNotBeEmpty()
        {
            var department = new Department("");

            var validator = new DepartmentValidator();
            var result = validator.Validate(department);

            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
            Assert.Contains(result.Errors, p => p.ErrorMessage == "Name should not be empty");
        }

        [Fact]
        public void Name_ShouldNotBeNull()
        {
            var department = new Department(null);

            var validator = new DepartmentValidator();
            var result = validator.Validate(department);

            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
            Assert.Contains(result.Errors, p => p.ErrorMessage == "Name should not be empty");
        }

        [Fact]
        public void Name_ShouldNotHaveMoreThan70characters()
        {
            var department = new Department("01234567890123456789012345678901234567890123456789012345678901234567890");

            var validator = new DepartmentValidator();
            var result = validator.Validate(department);

            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
            Assert.Contains(result.Errors, p => p.ErrorMessage == "Name length must be maximum 70 characters");
        }

        [Fact]
        public void Name_ShouldNotHaveLessThan3characters()
        {
            var department = new Department("01");

            var validator = new DepartmentValidator();
            var result = validator.Validate(department);

            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
            Assert.Contains(result.Errors, p => p.ErrorMessage == "Name must have at least 3 characters");
        }

        [Fact]
        public void Name_ShouldHaveMininum3_AndShouldHavaMaximum70_Characters()
        {
            var department = new Department(VALID_NAME);

            var validator = new DepartmentValidator();
            var result = validator.Validate(department);

            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

    }
}
