using FluentValidation;
using Library.SharedKernel.Dto;

namespace Library.Application.Validators
{
    public class RegisterCreateClientDtoValidator : AbstractValidator<CreateClientDto>
    {
        public RegisterCreateClientDtoValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(c => c.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}