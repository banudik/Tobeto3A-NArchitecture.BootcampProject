using Application.Features.Bootcamps.Constants;
using Application.Features.Bootcamps.Queries.GetList;
using Application.Features.Bootcamps.Rules;
using Application.Features.Employees.Constants;
using Application.Features.Instructors.Constants;
using Application.Services.BootcampImages;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using NArchitecture.Core.ElasticSearch;
using NArchitecture.Core.ElasticSearch.Models;
using Nest;
using static Application.Features.Bootcamps.Constants.BootcampsOperationClaims;

namespace Application.Features.Bootcamps.Commands.Create;

public class CreateBootcampCommand
    : MediatR.IRequest<CreatedBootcampResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public string Name { get; set; }
    public Guid InstructorId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public short BootcampStateId { get; set; }
    public IFormFile File { get; set; }
    public string Description { get; set; }

    public string[] Roles => [Admin, Write, BootcampsOperationClaims.Create, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBootcamps"];

    public class CreateBootcampCommandHandler : IRequestHandler<CreateBootcampCommand, CreatedBootcampResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampRepository _bootcampRepository;
        private readonly BootcampBusinessRules _bootcampBusinessRules;
        private readonly IBootcampImageService _bootcampImageService;
        private readonly IElasticSearch _elasticSearch;

        public CreateBootcampCommandHandler(
            IMapper mapper,
            IBootcampRepository bootcampRepository,
            BootcampBusinessRules bootcampBusinessRules,IBootcampImageService bootcampImageService,IElasticSearch elasticSearch
        )
        {
            _mapper = mapper;
            _bootcampRepository = bootcampRepository;
            _bootcampBusinessRules = bootcampBusinessRules;
            _bootcampImageService = bootcampImageService;
            _elasticSearch = elasticSearch;
        }

        public async Task<CreatedBootcampResponse> Handle(CreateBootcampCommand request, CancellationToken cancellationToken)
        {
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);

            var item = await _bootcampRepository.AddAsync(bootcamp);

            BootcampImage ImageToAdd = new BootcampImage()
            {
                BootcampId = item.Id,
                ImagePath = "asd"
            };

            var image = await _bootcampImageService.AddAsync(request.File, ImageToAdd);
            item.BootcampImageId = image.Id;
            await _bootcampRepository.UpdateAsync(item);

            CreatedBootcampResponse response = _mapper.Map<CreatedBootcampResponse>(bootcamp);
            return response;
        }
    }
}
