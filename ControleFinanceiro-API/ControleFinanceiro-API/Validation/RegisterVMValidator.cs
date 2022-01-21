using ControleFinanceiro_API.ViewModels;
using FluentValidation;

namespace ControleFinanceiro_API.Validation
{
    public class RegisterVMValidator : AbstractValidator<RegisterVM>
    {
        public RegisterVMValidator()
        {
            RuleFor(u => u.UserName)
                .NotEmpty().WithMessage("Enter Name")
                .NotNull().WithMessage("Enter Name")
                .MaximumLength(80).WithMessage("The name must be less than 80 characters")
                .MinimumLength(2).WithMessage("The name must be longer than 3 characters");

            RuleFor(u => u.CPF)
                .NotNull().WithMessage("Enter CPF")
                .NotEmpty().WithMessage("Enter CPF");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Enter Email")
                .NotNull().WithMessage("Enter Email")
                .MaximumLength(100).WithMessage("The name must be less than 100 characters")
                .MinimumLength(8).WithMessage("The name must be longer than 3 characters")
                .EmailAddress().WithMessage("E-mail invalid") ;

            RuleFor(u => u.Profissao)
                .NotNull().WithMessage("Enter Profession")
                .NotEmpty().WithMessage("Enter Profession")
                .MaximumLength(30).WithMessage("The Profession must be less than 30 characters")
                .MinimumLength(2).WithMessage("The Profession must be longer than 2 characters");

            RuleFor(u => u.Password)
                .NotNull().WithMessage("Enter Password")
                .NotEmpty().WithMessage("Enter Password")
                .MaximumLength(17).WithMessage("The Password must be less than 17 characters")
                .MinimumLength(5).WithMessage("The Password must be longer than 5 characters");

        }
    }
}
