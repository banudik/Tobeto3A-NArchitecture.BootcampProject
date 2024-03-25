using FluentValidation;

namespace Application.Features.BootcampStates.Commands.Create;

public class CreateBootcampStateCommandValidator : AbstractValidator<CreateBootcampStateCommand>
{
    public CreateBootcampStateCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}
