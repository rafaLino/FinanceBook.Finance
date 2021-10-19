using FluentValidation;

namespace FinanceBook.Finance.Application.Commands.UpdateGroup
{
    public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
    {
        public UpdateGroupCommandValidator()
        {
            RuleFor(f => f.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Group id is required");

            RuleFor(f => f.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("The name is required");

        }
    }
}
