using FluentValidation;

namespace Application.Features.ApplicationInformations.Commands.Delete;

public class DeleteApplicationInformationCommandValidator : AbstractValidator<DeleteApplicationInformationCommand>
{
    public DeleteApplicationInformationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
