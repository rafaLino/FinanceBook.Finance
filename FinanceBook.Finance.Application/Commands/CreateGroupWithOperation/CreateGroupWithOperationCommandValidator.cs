using FinanceBook.Finance.Domain;
using FluentValidation;

namespace FinanceBook.Finance.Application.Commands.CreateGroupWithOperation
{
    public class CreateGroupWithOperationCommandValidator : AbstractValidator<CreateGroupWithOperationCommand>
    {
        public CreateGroupWithOperationCommandValidator()
        {
            RuleFor(f => f.AccountId)
                .NotEmpty()
                .NotNull()
                .WithMessage("The accountId is required");

            RuleFor(f => f.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("The name is required");


            RuleFor(f => f.Category)
                .NotNull()
                .WithMessage("The category is required")
                .IsEnumName(typeof(Category), caseSensitive: false)
                .WithMessage("The category must be expense, income or investment");

            RuleFor(f => f.Amount)
                .NotNull()
                .WithMessage("The amount is required")
                .GreaterThanOrEqualTo(0)
                .WithMessage("The amount cannot be less than zero");
        }
    }
}
