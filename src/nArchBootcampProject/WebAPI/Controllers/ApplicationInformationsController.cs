using Application.Features.ApplicationInformations.Commands.Create;
using Application.Features.ApplicationInformations.Commands.Delete;
using Application.Features.ApplicationInformations.Commands.Update;
using Application.Features.ApplicationInformations.Queries.GetById;
using Application.Features.ApplicationInformations.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationInformationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateApplicationInformationCommand createApplicationInformationCommand)
    {
        CreatedApplicationInformationResponse response = await Mediator.Send(createApplicationInformationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateApplicationInformationCommand updateApplicationInformationCommand)
    {
        UpdatedApplicationInformationResponse response = await Mediator.Send(updateApplicationInformationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedApplicationInformationResponse response = await Mediator.Send(new DeleteApplicationInformationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdApplicationInformationResponse response = await Mediator.Send(new GetByIdApplicationInformationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListApplicationInformationQuery getListApplicationInformationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListApplicationInformationListItemDto> response = await Mediator.Send(
            getListApplicationInformationQuery
        );
        return Ok(response);
    }
}
