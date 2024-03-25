using System.Linq.Expressions;
using Application.Features.BootcampImages.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.BootcampImages;

public class BootcampImageManager : IBootcampImageService
{
    private readonly IBootcampImageRepository _bootcampImageRepository;
    private readonly BootcampImageBusinessRules _bootcampImageBusinessRules;

    public BootcampImageManager(
        IBootcampImageRepository bootcampImageRepository,
        BootcampImageBusinessRules bootcampImageBusinessRules
    )
    {
        _bootcampImageRepository = bootcampImageRepository;
        _bootcampImageBusinessRules = bootcampImageBusinessRules;
    }

    public async Task<BootcampImage?> GetAsync(
        Expression<Func<BootcampImage, bool>> predicate,
        Func<IQueryable<BootcampImage>, IIncludableQueryable<BootcampImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BootcampImage? bootcampImage = await _bootcampImageRepository.GetAsync(
            predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bootcampImage;
    }

    public async Task<IPaginate<BootcampImage>?> GetListAsync(
        Expression<Func<BootcampImage, bool>>? predicate = null,
        Func<IQueryable<BootcampImage>, IOrderedQueryable<BootcampImage>>? orderBy = null,
        Func<IQueryable<BootcampImage>, IIncludableQueryable<BootcampImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BootcampImage> bootcampImageList = await _bootcampImageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bootcampImageList;
    }

    public async Task<BootcampImage> AddAsync(BootcampImage bootcampImage)
    {
        BootcampImage addedBootcampImage = await _bootcampImageRepository.AddAsync(bootcampImage);

        return addedBootcampImage;
    }

    public async Task<BootcampImage> UpdateAsync(BootcampImage bootcampImage)
    {
        BootcampImage updatedBootcampImage = await _bootcampImageRepository.UpdateAsync(bootcampImage);

        return updatedBootcampImage;
    }

    public async Task<BootcampImage> DeleteAsync(BootcampImage bootcampImage, bool permanent = false)
    {
        BootcampImage deletedBootcampImage = await _bootcampImageRepository.DeleteAsync(bootcampImage);

        return deletedBootcampImage;
    }
}
