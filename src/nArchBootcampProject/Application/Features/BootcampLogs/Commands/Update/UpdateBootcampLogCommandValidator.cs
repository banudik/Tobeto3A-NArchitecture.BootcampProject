using FluentValidation;

namespace Application.Features.BootcampLogs.Commands.Update;

public class UpdateBootcampLogCommandValidator : AbstractValidator<UpdateBootcampLogCommand>
{
    public UpdateBootcampLogCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BootcampId).NotEmpty();
        RuleFor(c => c.ChapterId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.Bootcamp).NotEmpty();
        RuleFor(c => c.User).NotEmpty();
    }
}