using Application.Features.Blacklists.Commands.Create;
using Application.Features.Blacklists.Commands.Delete;
using Application.Features.Blacklists.Commands.Update;
using Application.Features.Blacklists.Queries.GetById;
using Application.Features.Blacklists.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlacklistsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBlacklistCommand createBlacklistCommand)
    {
        CreatedBlacklistResponse response = await Mediator.Send(createBlacklistCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBlacklistCommand updateBlacklistCommand)
    {
        UpdatedBlacklistResponse response = await Mediator.Send(updateBlacklistCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedBlacklistResponse response = await Mediator.Send(new DeleteBlacklistCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdBlacklistResponse response = await Mediator.Send(new GetByIdBlacklistQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBlacklistQuery getListBlacklistQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBlacklistListItemDto> response = await Mediator.Send(getListBlacklistQuery);
        return Ok(response);
    }
}
