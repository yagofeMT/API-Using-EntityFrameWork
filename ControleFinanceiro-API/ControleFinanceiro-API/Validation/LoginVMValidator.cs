using ControleFinanceiro_API.ViewModels;
using FluentValidation;

namespace ControleFinanceiro_API.Validation
{
    public class LoginVMValidator : AbstractValidator<LoginVM>
    {
        public LoginVMValidator()
        {

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Enter Email")
                .NotNull().WithMessage("Enter Email")
                .MaximumLength(100).WithMessage("The name must be less than 100 characters")
                .MinimumLength(8).WithMessage("The name must be longer than 3 characters")
                .EmailAddress().WithMessage("E-mail invalid");

            RuleFor(u => u.Password)
                .NotNull().WithMessage("Enter Password")
                .NotEmpty().WithMessage("Enter Password")
                .MaximumLength(17).WithMessage("The Password must be less than 17 characters")
                .MinimumLength(5).WithMessage("The Password must be longer than 5 characters");
        }
    }
}
