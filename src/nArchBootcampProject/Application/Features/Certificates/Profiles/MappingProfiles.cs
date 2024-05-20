using Application.Features.Certificates.Commands.Create;
using Application.Features.Certificates.Commands.Delete;
using Application.Features.Certificates.Commands.Update;
using Application.Features.Certificates.Queries.GetById;
using Application.Features.Certificates.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Certificates.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCertificateCommand, Certificate>();
        CreateMap<Certificate, CreatedCertificateResponse>();

        CreateMap<UpdateCertificateCommand, Certificate>();
        CreateMap<Certificate, UpdatedCertificateResponse>();

        CreateMap<DeleteCertificateCommand, Certificate>();
        CreateMap<Certificate, DeletedCertificateResponse>();

        CreateMap<Certificate, GetByIdCertificateResponse>();

        CreateMap<Certificate, GetListCertificateListItemDto>();
        CreateMap<IPaginate<Certificate>, GetListResponse<GetListCertificateListItemDto>>();
    }
}