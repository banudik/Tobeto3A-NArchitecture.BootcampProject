using Application.Features.BootcampStates.Commands.Create;
using Application.Features.BootcampStates.Commands.Delete;
using Application.Features.BootcampStates.Commands.Update;
using Application.Features.BootcampStates.Queries.GetById;
using Application.Features.BootcampStates.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BootcampStatesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBootcampStateCommand createBootcampStateCommand)
    {
        CreatedBootcampStateResponse response = await Mediator.Send(createBootcampStateCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBootcampStateCommand updateBootcampStateCommand)
    {
        UpdatedBootcampStateResponse response = await Mediator.Send(updateBootcampStateCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] short id)
    {
        DeletedBootcampStateResponse response = await Mediator.Send(new DeleteBootcampStateCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] short id)
    {
        GetByIdBootcampStateResponse response = await Mediator.Send(new GetByIdBootcampStateQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBootcampStateQuery getListBootcampStateQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBootcampStateListItemDto> response = await Mediator.Send(getListBootcampStateQuery);
        return Ok(response);
    }
}
