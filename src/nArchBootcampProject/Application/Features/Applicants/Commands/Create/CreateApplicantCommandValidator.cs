using FluentValidation;

namespace Application.Features.Applicants.Commands.Create;

public class CreateApplicantCommandValidator : AbstractValidator<CreateApplicantCommand>
{
    public CreateApplicantCommandValidator()
    {
        RuleFor(c => c.About).NotEmpty();
    }
}
