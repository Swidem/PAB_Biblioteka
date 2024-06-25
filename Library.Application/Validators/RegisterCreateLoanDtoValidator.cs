using FluentValidation;
using Library.SharedKernel.Dto;

namespace Library.Application.Validators
{
    public class RegisterCreateLoanDtoValidator : AbstractValidator<CreateLoanDto>
    {
        public RegisterCreateLoanDtoValidator()
        {
            RuleFor(l => l.ClientId)
                .GreaterThan(0);

            RuleFor(l => l.BookId)
                .GreaterThan(0);

            RuleFor(l => l.EmployeeId)
                .GreaterThan(0);

            RuleFor(l => l.LoanDate)
                .NotEmpty();

            RuleFor(l => l.DueDate)
                .NotEmpty()
                .GreaterThan(l => l.LoanDate);
        }
    }
}
