using FluentValidation;

namespace FinanceBook.Finance.Application.Commands.UpdateOperation
{
    public class UpdateOperationCommandValidator : AbstractValidator<UpdateOperationCommand>
    {
        public UpdateOperationCommandValidator()
        {
            RuleFor(f => f.Id)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage("Operation id is required");

            RuleFor(f => f.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("The name is required");

            RuleFor(f => f.Amount)
                .NotNull()
                .WithMessage("The amount is required")
                .GreaterThanOrEqualTo(0)
                .WithMessage("The amount cannot be less than zero");

        }
    }
}
