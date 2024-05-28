using Application.Features.BootcampLogs.Commands.Create;
using Application.Features.BootcampLogs.Commands.Delete;
using Application.Features.BootcampLogs.Commands.Update;
using Application.Features.BootcampLogs.Queries.GetById;
using Application.Features.BootcampLogs.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.BootcampLogs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BootcampLog, CreateBootcampLogCommand>().ReverseMap();
        CreateMap<BootcampLog, CreatedBootcampLogResponse>().ReverseMap();
        CreateMap<BootcampLog, UpdateBootcampLogCommand>().ReverseMap();
        CreateMap<BootcampLog, UpdatedBootcampLogResponse>().ReverseMap();
        CreateMap<BootcampLog, DeleteBootcampLogCommand>().ReverseMap();
        CreateMap<BootcampLog, DeletedBootcampLogResponse>().ReverseMap();
        CreateMap<BootcampLog, GetByIdBootcampLogResponse>().ReverseMap();
        CreateMap<BootcampLog, GetListBootcampLogListItemDto>().ReverseMap();
        CreateMap<IPaginate<BootcampLog>, GetListResponse<GetListBootcampLogListItemDto>>().ReverseMap();
    }
}