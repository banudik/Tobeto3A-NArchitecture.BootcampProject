using FluentValidation;

namespace Application.Features.BootcampLogs.Commands.Create;

public class CreateBootcampLogCommandValidator : AbstractValidator<CreateBootcampLogCommand>
{
    public CreateBootcampLogCommandValidator()
    {
        RuleFor(c => c.BootcampId).NotEmpty();
        RuleFor(c => c.ChapterId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}