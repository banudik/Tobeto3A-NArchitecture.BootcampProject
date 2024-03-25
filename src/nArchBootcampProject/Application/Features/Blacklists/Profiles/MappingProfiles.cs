using Application.Features.Blacklists.Commands.Create;
using Application.Features.Blacklists.Commands.Delete;
using Application.Features.Blacklists.Commands.Update;
using Application.Features.Blacklists.Queries.GetById;
using Application.Features.Blacklists.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Blacklists.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Blacklist, CreateBlacklistCommand>().ReverseMap();
        CreateMap<Blacklist, CreatedBlacklistResponse>().ReverseMap();
        CreateMap<Blacklist, UpdateBlacklistCommand>().ReverseMap();
        CreateMap<Blacklist, UpdatedBlacklistResponse>().ReverseMap();
        CreateMap<Blacklist, DeleteBlacklistCommand>().ReverseMap();
        CreateMap<Blacklist, DeletedBlacklistResponse>().ReverseMap();
        CreateMap<Blacklist, GetByIdBlacklistResponse>().ReverseMap();
        CreateMap<Blacklist, GetListBlacklistListItemDto>().ReverseMap();
        CreateMap<IPaginate<Blacklist>, GetListResponse<GetListBlacklistListItemDto>>().ReverseMap();
    }
}
