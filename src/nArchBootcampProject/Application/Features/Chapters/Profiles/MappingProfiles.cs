using Application.Features.Chapters.Commands.Create;
using Application.Features.Chapters.Commands.Delete;
using Application.Features.Chapters.Commands.Update;
using Application.Features.Chapters.Queries.GetById;
using Application.Features.Chapters.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Chapters.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Chapter, CreateChapterCommand>().ReverseMap();
        CreateMap<Chapter, CreatedChapterResponse>().ReverseMap();
        CreateMap<Chapter, UpdateChapterCommand>().ReverseMap();
        CreateMap<Chapter, UpdatedChapterResponse>().ReverseMap();
        CreateMap<Chapter, DeleteChapterCommand>().ReverseMap();
        CreateMap<Chapter, DeletedChapterResponse>().ReverseMap();
        CreateMap<Chapter, GetByIdChapterResponse>().ReverseMap();
        CreateMap<Chapter, GetListChapterListItemDto>().ReverseMap();
        CreateMap<IPaginate<Chapter>, GetListResponse<GetListChapterListItemDto>>().ReverseMap();
    }
}