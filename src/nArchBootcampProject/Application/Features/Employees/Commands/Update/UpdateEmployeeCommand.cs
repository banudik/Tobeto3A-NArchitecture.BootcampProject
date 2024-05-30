using Application.Features.Employees.Constants;
using Application.Features.Employees.Rules;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using NArchitecture.Core.Security.Entities;
using NArchitecture.Core.Security.Hashing;
using static Application.Features.Employees.Constants.EmployeesOperationClaims;

namespace Application.Features.Employees.Commands.Update;

public class UpdateEmployeeCommand
    : IRequest<UpdatedEmployeeResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string Position { get; set; }
    public string? Password { get; set; }
    public string? NewPassword { get; set; }

    public string[] Roles => [Admin, Write, EmployeesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetEmployees"];

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, UpdatedEmployeeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeBusinessRules _employeeBusinessRules;

        public UpdateEmployeeCommandHandler(
            IMapper mapper,
            IEmployeeRepository employeeRepository,
            EmployeeBusinessRules employeeBusinessRules
        )
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _employeeBusinessRules = employeeBusinessRules;
        }

        public async Task<UpdatedEmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee? employee = await _employeeRepository.GetAsync(
                predicate: e => e.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _employeeBusinessRules.EmployeeShouldExistWhenSelected(employee);
            await _employeeBusinessRules.EmployeeEmailShouldNotExistsWhenUpdate(employee!.Id, employee.Email);
            
            employee = _mapper.Map(request, employee);

            if (request.NewPassword != null && !string.IsNullOrWhiteSpace(request.NewPassword))
            {
                await _employeeBusinessRules.EmployeePasswordShouldBeMatched(user: employee!, request.Password);
                HashingHelper.CreatePasswordHash(
                    request.NewPassword,
                    passwordHash: out byte[] passwordHash,
                    passwordSalt: out byte[] passwordSalt
                );
                employee!.PasswordHash = passwordHash;
                employee!.PasswordSalt = passwordSalt;
            }

            await _employeeRepository.UpdateAsync(employee!);

            UpdatedEmployeeResponse response = _mapper.Map<UpdatedEmployeeResponse>(employee);
            return response;
        }
    }
}
