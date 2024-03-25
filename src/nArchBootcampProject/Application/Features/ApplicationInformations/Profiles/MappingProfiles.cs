using Application.Features.ApplicationInformations.Commands.Create;
using Application.Features.ApplicationInformations.Commands.Delete;
using Application.Features.ApplicationInformations.Commands.Update;
using Application.Features.ApplicationInformations.Queries.GetById;
using Application.Features.ApplicationInformations.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.ApplicationInformations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ApplicationInformation, CreateApplicationInformationCommand>().ReverseMap();
        CreateMap<ApplicationInformation, CreatedApplicationInformationResponse>().ReverseMap();
        CreateMap<ApplicationInformation, UpdateApplicationInformationCommand>().ReverseMap();
        CreateMap<ApplicationInformation, UpdatedApplicationInformationResponse>().ReverseMap();
        CreateMap<ApplicationInformation, DeleteApplicationInformationCommand>().ReverseMap();
        CreateMap<ApplicationInformation, DeletedApplicationInformationResponse>().ReverseMap();
        CreateMap<ApplicationInformation, GetByIdApplicationInformationResponse>().ReverseMap();
        CreateMap<ApplicationInformation, GetListApplicationInformationListItemDto>().ReverseMap();
        CreateMap<IPaginate<ApplicationInformation>, GetListResponse<GetListApplicationInformationListItemDto>>().ReverseMap();
    }
}
