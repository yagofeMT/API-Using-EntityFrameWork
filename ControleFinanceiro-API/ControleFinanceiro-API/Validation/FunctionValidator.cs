using ControleFinanceiro.BLL.Models;
using ControleFinanceiro_API.ViewModels;
using FluentValidation;

namespace ControleFinanceiro_API.Validation
{
    public class FunctionValidator : AbstractValidator<FunctionsViewModel>
    {
        public FunctionValidator()
        {
            RuleFor(f => f.Name)
                .MinimumLength(4).WithMessage("The name must be longer than 4 characters")
                .MaximumLength(50).WithMessage("the name must be less than 50 caracts")
                .NotEmpty().WithMessage("Enter Name")
                .NotNull().WithMessage("Enter Name");


            RuleFor(f => f.Description)
                .NotNull().WithMessage("Enter Description")
                .NotEmpty().WithMessage("Enter Description")
                .MinimumLength(4).WithMessage("The name must be longer than 4 characters")
                .MaximumLength(50).WithMessage("The name must be less than 50 characters");
        }
    }
}
