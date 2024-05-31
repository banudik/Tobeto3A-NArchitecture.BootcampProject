using Application.Features.BootcampLogs.Commands.Create;
using Application.Features.BootcampLogs.Commands.Delete;
using Application.Features.BootcampLogs.Commands.Update;
using Application.Features.BootcampLogs.Queries.GetById;
using Application.Features.BootcampLogs.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Bootcamps.Queries.GetList;
using NArchitecture.Core.Persistence.Dynamic;
using Application.Features.Comments.Queries.GetList;
using Application.Features.Comments.Queries.GetListDynamic;
using Application.Features.BootcampLogs.Queries.GetListByUserId;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BootcampLogsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBootcampLogCommand createBootcampLogCommand)
    {
        CreatedBootcampLogResponse response = await Mediator.Send(createBootcampLogCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBootcampLogCommand updateBootcampLogCommand)
    {
        UpdatedBootcampLogResponse response = await Mediator.Send(updateBootcampLogCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedBootcampLogResponse response = await Mediator.Send(new DeleteBootcampLogCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdBootcampLogResponse response = await Mediator.Send(new GetByIdBootcampLogQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBootcampLogQuery getListBootcampLogQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBootcampLogListItemDto> response = await Mediator.Send(getListBootcampLogQuery);
        return Ok(response);
    }

    [HttpGet("getlistbyuserid")]
    public async Task<IActionResult> GetListByUserId([FromQuery] PageRequest pageRequest, Guid userId, int bootcampId)
    {
        GetListBootcampLogByUserIdQuery getListBootcampLogQuery = new() { PageRequest = pageRequest, UserId = userId, BootcampId = bootcampId };
        GetListResponse<GetListBootcampLogListItemDto> response = await Mediator.Send(getListBootcampLogQuery);
        return Ok(response);
    }

    [HttpPost("dynamic")]
    public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamic)
    {
        GetListCommentDynamicQuery commentDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
        GetListResponse<GetListCommentListItemDto> response = await Mediator.Send(commentDynamicQuery);
        return Ok(response);

    }
}