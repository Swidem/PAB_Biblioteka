using FluentValidation;
using Library.SharedKernel.Dto;

namespace Library.Application.Validators
{
    public class RegisterCreateEmployeeDtoValidator : AbstractValidator<CreateEmployeeDto>
    {
        public RegisterCreateEmployeeDtoValidator()
        {
            RuleFor(e => e.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(e => e.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(e => e.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}