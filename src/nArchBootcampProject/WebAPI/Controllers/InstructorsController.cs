using Application.Features.Instructors.Commands.Create;
using Application.Features.Instructors.Commands.Delete;
using Application.Features.Instructors.Commands.Update;
using Application.Features.Instructors.Queries.GetById;
using Application.Features.Instructors.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstructorsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateInstructorCommand createInstructorCommand)
    {
        CreatedInstructorResponse response = await Mediator.Send(createInstructorCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateInstructorCommand updateInstructorCommand)
    {
        UpdatedInstructorResponse response = await Mediator.Send(updateInstructorCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedInstructorResponse response = await Mediator.Send(new DeleteInstructorCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdInstructorResponse response = await Mediator.Send(new GetByIdInstructorQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListInstructorQuery getListInstructorQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListInstructorListItemDto> response = await Mediator.Send(getListInstructorQuery);
        return Ok(response);
    }
}
