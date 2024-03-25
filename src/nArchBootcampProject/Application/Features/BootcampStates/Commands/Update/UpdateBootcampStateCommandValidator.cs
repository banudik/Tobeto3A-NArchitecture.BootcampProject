using FluentValidation;

namespace Application.Features.BootcampStates.Commands.Update;

public class UpdateBootcampStateCommandValidator : AbstractValidator<UpdateBootcampStateCommand>
{
    public UpdateBootcampStateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}
