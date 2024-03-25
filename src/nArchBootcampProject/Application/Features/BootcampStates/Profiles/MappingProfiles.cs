using Application.Features.BootcampStates.Commands.Create;
using Application.Features.BootcampStates.Commands.Delete;
using Application.Features.BootcampStates.Commands.Update;
using Application.Features.BootcampStates.Queries.GetById;
using Application.Features.BootcampStates.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.BootcampStates.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BootcampState, CreateBootcampStateCommand>().ReverseMap();
        CreateMap<BootcampState, CreatedBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, UpdateBootcampStateCommand>().ReverseMap();
        CreateMap<BootcampState, UpdatedBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, DeleteBootcampStateCommand>().ReverseMap();
        CreateMap<BootcampState, DeletedBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, GetByIdBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, GetListBootcampStateListItemDto>().ReverseMap();
        CreateMap<IPaginate<BootcampState>, GetListResponse<GetListBootcampStateListItemDto>>().ReverseMap();
    }
}
