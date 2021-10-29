using FinanceBook.Finance.Domain;
using FluentValidation;

namespace FinanceBook.Finance.Application.Commands.CreateGroupWithOperations
{
    public class CreateGroupWithOperationsCommandValidator : AbstractValidator<CreateGroupWithOperationsCommand>
    {
        public CreateGroupWithOperationsCommandValidator()
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

            RuleFor(f => f.Operations)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("The operations is required");
        }
    }
}
