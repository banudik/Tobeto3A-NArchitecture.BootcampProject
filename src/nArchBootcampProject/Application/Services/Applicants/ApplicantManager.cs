using System.Linq.Expressions;
using Application.Features.Applicants.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.Applicants;

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly ApplicantBusinessRules _applicantBusinessRules;

    public ApplicantManager(IApplicantRepository applicantRepository, ApplicantBusinessRules applicantBusinessRules)
    {
        _applicantRepository = applicantRepository;
        _applicantBusinessRules = applicantBusinessRules;
    }

    public async Task<Applicant?> GetAsync(
        Expression<Func<Applicant, bool>> predicate,
        Func<IQueryable<Applicant>, IIncludableQueryable<Applicant, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Applicant? applicant = await _applicantRepository.GetAsync(
            predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return applicant;
    }

    public async Task<IPaginate<Applicant>?> GetListAsync(
        Expression<Func<Applicant, bool>>? predicate = null,
        Func<IQueryable<Applicant>, IOrderedQueryable<Applicant>>? orderBy = null,
        Func<IQueryable<Applicant>, IIncludableQueryable<Applicant, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Applicant> applicantList = await _applicantRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return applicantList;
    }

    public async Task<Applicant> AddAsync(Applicant applicant)
    {
        Applicant addedApplicant = await _applicantRepository.AddAsync(applicant);

        return addedApplicant;
    }

    public async Task<Applicant> UpdateAsync(Applicant applicant)
    {
        Applicant updatedApplicant = await _applicantRepository.UpdateAsync(applicant);

        return updatedApplicant;
    }

    public async Task<Applicant> DeleteAsync(Applicant applicant, bool permanent = false)
    {
        Applicant deletedApplicant = await _applicantRepository.DeleteAsync(applicant);

        return deletedApplicant;
    }
}
