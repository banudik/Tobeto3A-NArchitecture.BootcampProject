using FluentValidation;

namespace Application.Features.BootcampLogs.Commands.Delete;

public class DeleteBootcampLogCommandValidator : AbstractValidator<DeleteBootcampLogCommand>
{
    public DeleteBootcampLogCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}