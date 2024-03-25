using FluentValidation;

namespace Application.Features.Applicants.Commands.Delete;

public class DeleteApplicantCommandValidator : AbstractValidator<DeleteApplicantCommand>
{
    public DeleteApplicantCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
