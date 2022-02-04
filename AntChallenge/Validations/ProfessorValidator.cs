using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using FluentValidation;

namespace AntChallenge.Validations
{
    public class ProfessorValidator : AbstractValidator<Professor>
    {
        public ProfessorValidator()
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
