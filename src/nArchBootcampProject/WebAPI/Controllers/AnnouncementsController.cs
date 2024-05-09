using Application.Features.Announcements.Commands.Create;
using Application.Features.Announcements.Commands.Delete;
using Application.Features.Announcements.Commands.Update;
using Application.Features.Announcements.Queries.GetById;
using Application.Features.Announcements.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnnouncementsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedAnnouncementResponse>> Add([FromBody] CreateAnnouncementCommand command)
    {
        CreatedAnnouncementResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedAnnouncementResponse>> Update([FromBody] UpdateAnnouncementCommand command)
    {
        UpdatedAnnouncementResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedAnnouncementResponse>> Delete([FromRoute] int id)
    {
        DeleteAnnouncementCommand command = new() { Id = id };

        DeletedAnnouncementResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdAnnouncementResponse>> GetById([FromRoute] int id)
    {
        GetByIdAnnouncementQuery query = new() { Id = id };

        GetByIdAnnouncementResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListAnnouncementQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAnnouncementQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListAnnouncementListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}