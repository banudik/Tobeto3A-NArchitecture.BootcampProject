using System.Linq.Expressions;
using Application.Features.Employees.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.Employees;

public class EmployeeManager : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly EmployeeBusinessRules _employeeBusinessRules;

    public EmployeeManager(IEmployeeRepository employeeRepository, EmployeeBusinessRules employeeBusinessRules)
    {
        _employeeRepository = employeeRepository;
        _employeeBusinessRules = employeeBusinessRules;
    }

    public async Task<Employee?> GetAsync(
        Expression<Func<Employee, bool>> predicate,
        Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Employee? employee = await _employeeRepository.GetAsync(
            predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return employee;
    }

    public async Task<IPaginate<Employee>?> GetListAsync(
        Expression<Func<Employee, bool>>? predicate = null,
        Func<IQueryable<Employee>, IOrderedQueryable<Employee>>? orderBy = null,
        Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Employee> employeeList = await _employeeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return employeeList;
    }

    public async Task<Employee> AddAsync(Employee employee)
    {
        Employee addedEmployee = await _employeeRepository.AddAsync(employee);

        return addedEmployee;
    }

    public async Task<Employee> UpdateAsync(Employee employee)
    {
        Employee updatedEmployee = await _employeeRepository.UpdateAsync(employee);

        return updatedEmployee;
    }

    public async Task<Employee> DeleteAsync(Employee employee, bool permanent = false)
    {
        Employee deletedEmployee = await _employeeRepository.DeleteAsync(employee);

        return deletedEmployee;
    }
}
