using Application.Features.Applicants.Commands.Create;
using Application.Features.Applicants.Commands.Delete;
using Application.Features.Applicants.Commands.Update;
using Application.Features.Applicants.Queries.GetById;
using Application.Features.Applicants.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Applicants.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Applicant, CreateApplicantCommand>().ReverseMap();
        CreateMap<Applicant, CreatedApplicantResponse>().ReverseMap();
        CreateMap<Applicant, UpdateApplicantCommand>().ReverseMap();
        CreateMap<Applicant, UpdatedApplicantResponse>().ReverseMap();
        CreateMap<Applicant, DeleteApplicantCommand>().ReverseMap();
        CreateMap<Applicant, DeletedApplicantResponse>().ReverseMap();
        CreateMap<Applicant, GetByIdApplicantResponse>().ReverseMap();
        CreateMap<Applicant, GetListApplicantListItemDto>().ReverseMap();
        CreateMap<IPaginate<Applicant>, GetListResponse<GetListApplicantListItemDto>>().ReverseMap();
    }
}
