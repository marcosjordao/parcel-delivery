using FluentValidation;
using ParcelDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelDelivery.Services.Validators
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(p => p.Name).NotEmpty()
                                .WithMessage("Name should not be empty")
                                .MaximumLength(70)
                                .WithMessage("Name length must be maximum 70 characters")
                                .MinimumLength(3)
                                .WithMessage("Name must have at least 3 characters");
        }
    }
}
