using FluentValidation;

namespace Application.Features.Employees.Commands.Delete;

public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
