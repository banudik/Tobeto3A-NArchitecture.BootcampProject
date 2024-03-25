using FluentValidation;

namespace Application.Features.BootcampImages.Commands.Update;

public class UpdateBootcampImageCommandValidator : AbstractValidator<UpdateBootcampImageCommand>
{
    public UpdateBootcampImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BootcampId).NotEmpty();
        RuleFor(c => c.ImagePath).NotEmpty();
    }
}
