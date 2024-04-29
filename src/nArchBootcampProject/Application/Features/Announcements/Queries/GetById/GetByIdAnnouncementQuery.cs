using Application.Features.Announcements.Constants;
using Application.Features.Announcements.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Announcements.Constants.AnnouncementsOperationClaims;

namespace Application.Features.Announcements.Queries.GetById;

public class GetByIdAnnouncementQuery : IRequest<GetByIdAnnouncementResponse>//, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdAnnouncementQueryHandler : IRequestHandler<GetByIdAnnouncementQuery, GetByIdAnnouncementResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly AnnouncementBusinessRules _announcementBusinessRules;

        public GetByIdAnnouncementQueryHandler(IMapper mapper, IAnnouncementRepository announcementRepository, AnnouncementBusinessRules announcementBusinessRules)
        {
            _mapper = mapper;
            _announcementRepository = announcementRepository;
            _announcementBusinessRules = announcementBusinessRules;
        }

        public async Task<GetByIdAnnouncementResponse> Handle(GetByIdAnnouncementQuery request, CancellationToken cancellationToken)
        {
            Announcement? announcement = await _announcementRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _announcementBusinessRules.AnnouncementShouldExistWhenSelected(announcement);

            GetByIdAnnouncementResponse response = _mapper.Map<GetByIdAnnouncementResponse>(announcement);
            return response;
        }
    }
}