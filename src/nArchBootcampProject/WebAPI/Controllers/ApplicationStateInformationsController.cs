using Application.Features.ApplicationStateInformations.Commands.Create;
using Application.Features.ApplicationStateInformations.Commands.Delete;
using Application.Features.ApplicationStateInformations.Commands.Update;
using Application.Features.ApplicationStateInformations.Queries.GetById;
using Application.Features.ApplicationStateInformations.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationStateInformationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateApplicationStateInformationCommand createApplicationStateInformationCommand
    )
    {
        CreatedApplicationStateInformationResponse response = await Mediator.Send(createApplicationStateInformationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        [FromBody] UpdateApplicationStateInformationCommand updateApplicationStateInformationCommand
    )
    {
        UpdatedApplicationStateInformationResponse response = await Mediator.Send(updateApplicationStateInformationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] short id)
    {
        DeletedApplicationStateInformationResponse response = await Mediator.Send(
            new DeleteApplicationStateInformationCommand { Id = id }
        );

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] short id)
    {
        GetByIdApplicationStateInformationResponse response = await Mediator.Send(
            new GetByIdApplicationStateInformationQuery { Id = id }
        );
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListApplicationStateInformationQuery getListApplicationStateInformationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListApplicationStateInformationListItemDto> response = await Mediator.Send(
            getListApplicationStateInformationQuery
        );
        return Ok(response);
    }
}
