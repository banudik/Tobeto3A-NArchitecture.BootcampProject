using FluentValidation;

namespace Application.Features.Applicants.Commands.Update;

public class UpdateApplicantCommandValidator : AbstractValidator<UpdateApplicantCommand>
{
    public UpdateApplicantCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.About).NotEmpty();
    }
}
