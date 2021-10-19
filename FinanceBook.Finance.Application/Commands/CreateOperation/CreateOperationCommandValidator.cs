using FluentValidation;

namespace FinanceBook.Finance.Application.Commands.CreateOperation
{
    public class CreateOperationCommandValidator : AbstractValidator<CreateOperationCommand>
    {

        public CreateOperationCommandValidator()
        {
            RuleFor(f => f.GroupId)
                .NotNull()
                .NotEmpty()
                .WithMessage("The groupId is required");

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
