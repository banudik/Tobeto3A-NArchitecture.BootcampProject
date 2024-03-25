using FluentValidation;

namespace Application.Features.BootcampStates.Commands.Delete;

public class DeleteBootcampStateCommandValidator : AbstractValidator<DeleteBootcampStateCommand>
{
    public DeleteBootcampStateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
