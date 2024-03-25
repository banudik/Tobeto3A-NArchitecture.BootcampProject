using FluentValidation;

namespace Application.Features.Bootcamps.Commands.Delete;

public class DeleteBootcampCommandValidator : AbstractValidator<DeleteBootcampCommand>
{
    public DeleteBootcampCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
