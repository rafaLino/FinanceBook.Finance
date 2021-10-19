using FluentValidation;

namespace FinanceBook.Finance.Application.Commands.RemoveOperation
{
    public class RemoveOperationCommandValidator : AbstractValidator<RemoveOperationCommand>
    {
        public RemoveOperationCommandValidator()
        {
            RuleFor(f => f.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Operation id is required");
        }
    }
}
