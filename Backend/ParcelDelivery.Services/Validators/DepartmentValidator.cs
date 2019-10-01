using FluentValidation;
using ParcelDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Services.Validators
{
    class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(p => p.Name).NotEmpty()
                                .WithMessage("Name should not be empty")
                                .Length(3, 70)
                                .WithMessage("Invalid name");
        }
    }
}
