using AntChallenge.ViewModels;
using FluentValidation;

namespace AntChallenge.Validations
{
    public class StudentViewModelValidator : AbstractValidator<StudentViewModel>
    {
        public StudentViewModelValidator()
        {
            RuleFor(c => c.Id)
                .Must(x => x >= 0);
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
