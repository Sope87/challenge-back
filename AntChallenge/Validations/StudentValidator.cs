using DataAccessLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntChallenge.Validations
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required")
                .NotNull()
                .MaximumLength(50).WithMessage("Property must not exceed 50 characters");
            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Last Name is required")
                .NotNull()
                .MaximumLength(50).WithMessage("Property must not exceed 50 characters");
        }
    }
}
