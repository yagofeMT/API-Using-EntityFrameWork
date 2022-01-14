using ControleFinanceiro.BLL.Models;
using FluentValidation;

namespace ControleFinanceiro_API.Validation
{
    public class CategoryValidator : AbstractValidator<Category>
    {

        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .MinimumLength(3).WithMessage("The name must be longer than 3 characters")
                .NotNull().WithMessage("Enter name")
                .NotEmpty().WithMessage("Enter Name")
                .MaximumLength(50).WithMessage("the name must be less than 50 caracts");

            RuleFor(c => c.Icone)
              .MinimumLength(2).WithMessage("The icon must be longer than 1 characters")
              .NotNull().WithMessage("Enter icon")
              .NotEmpty().WithMessage("Enter icon")
              .MaximumLength(15).WithMessage("the icon must be less than 15 caracts");

            RuleFor(c => c.TypeId)
              .NotNull().WithMessage("Enter icon")
              .NotEmpty().WithMessage("Enter icon");
        }
    }
}
