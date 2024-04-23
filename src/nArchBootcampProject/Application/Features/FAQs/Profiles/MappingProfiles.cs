using Application.Features.FAQs.Commands.Create;
using Application.Features.FAQs.Commands.Delete;
using Application.Features.FAQs.Commands.Update;
using Application.Features.FAQs.Queries.GetById;
using Application.Features.FAQs.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.FAQs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<FAQ, CreateFAQCommand>().ReverseMap();
        CreateMap<FAQ, CreatedFAQResponse>().ReverseMap();
        CreateMap<FAQ, UpdateFAQCommand>().ReverseMap();
        CreateMap<FAQ, UpdatedFAQResponse>().ReverseMap();
        CreateMap<FAQ, DeleteFAQCommand>().ReverseMap();
        CreateMap<FAQ, DeletedFAQResponse>().ReverseMap();
        CreateMap<FAQ, GetByIdFAQResponse>().ReverseMap();
        CreateMap<FAQ, GetListFAQListItemDto>().ReverseMap();
        CreateMap<IPaginate<FAQ>, GetListResponse<GetListFAQListItemDto>>().ReverseMap();
    }
}