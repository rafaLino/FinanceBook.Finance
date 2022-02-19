using FluentValidation;

namespace FinanceBook.Finance.Application.Commands.RemoveGroup
{
    public class RemoveGroupCommandValidator : AbstractValidator<RemoveGroupCommand>
    {
        public RemoveGroupCommandValidator()
        {
            RuleFor(f => f.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Group id is required");
        }
    }
}
