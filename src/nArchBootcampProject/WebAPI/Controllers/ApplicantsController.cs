using Application.Features.Applicants.Commands.Create;
using Application.Features.Applicants.Commands.Delete;
using Application.Features.Applicants.Commands.Update;
using Application.Features.Applicants.Queries.GetById;
using Application.Features.Applicants.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicantsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateApplicantCommand createApplicantCommand)
    {
        CreatedApplicantResponse response = await Mediator.Send(createApplicantCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateApplicantCommand updateApplicantCommand)
    {
        UpdatedApplicantResponse response = await Mediator.Send(updateApplicantCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedApplicantResponse response = await Mediator.Send(new DeleteApplicantCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdApplicantResponse response = await Mediator.Send(new GetByIdApplicantQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListApplicantQuery getListApplicantQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListApplicantListItemDto> response = await Mediator.Send(getListApplicantQuery);
        return Ok(response);
    }
}
