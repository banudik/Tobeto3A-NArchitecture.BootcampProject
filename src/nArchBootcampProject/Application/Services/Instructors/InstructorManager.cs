using System.Linq.Expressions;
using Application.Features.Instructors.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.Instructors;

public class InstructorManager : IInstructorService
{
    private readonly IInstructorRepository _instructorRepository;
    private readonly InstructorBusinessRules _instructorBusinessRules;

    public InstructorManager(IInstructorRepository instructorRepository, InstructorBusinessRules instructorBusinessRules)
    {
        _instructorRepository = instructorRepository;
        _instructorBusinessRules = instructorBusinessRules;
    }

    public async Task<Instructor?> GetAsync(
        Expression<Func<Instructor, bool>> predicate,
        Func<IQueryable<Instructor>, IIncludableQueryable<Instructor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Instructor? instructor = await _instructorRepository.GetAsync(
            predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return instructor;
    }

    public async Task<IPaginate<Instructor>?> GetListAsync(
        Expression<Func<Instructor, bool>>? predicate = null,
        Func<IQueryable<Instructor>, IOrderedQueryable<Instructor>>? orderBy = null,
        Func<IQueryable<Instructor>, IIncludableQueryable<Instructor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Instructor> instructorList = await _instructorRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return instructorList;
    }

    public async Task<Instructor> AddAsync(Instructor instructor)
    {
        Instructor addedInstructor = await _instructorRepository.AddAsync(instructor);

        return addedInstructor;
    }

    public async Task<Instructor> UpdateAsync(Instructor instructor)
    {
        Instructor updatedInstructor = await _instructorRepository.UpdateAsync(instructor);

        return updatedInstructor;
    }

    public async Task<Instructor> DeleteAsync(Instructor instructor, bool permanent = false)
    {
        Instructor deletedInstructor = await _instructorRepository.DeleteAsync(instructor);

        return deletedInstructor;
    }
}
